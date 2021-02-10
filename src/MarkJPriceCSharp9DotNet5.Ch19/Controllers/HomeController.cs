using MarkJPriceCSharp9DotNet5.Ch19.Entities;
using MarkJPriceCSharp9DotNet5.Ch19.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MarkJPriceCSharp9DotNet5.Ch19.Controllers
{
    public class HomeController : Controller
    {
        private readonly static string DatasetName = "dataset.txt";
        private readonly static string[] Countries = { "Germany", "UK", "USA" };
        private readonly Northwind _db;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(Northwind db, ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _db = db;
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            var model = CreateHomeIndexViewModel();
            return View(model);
        }

        public IActionResult GenerateDatasets()
        {
            foreach (string country in Countries)
            {
                var ordersInCountry = _db.Orders
                    .Where(order => order.Customer.Country == country)
                    .Include(order => order.OrderDetails)
                    .AsEnumerable();

                var coboughtProducts = ordersInCountry
                    .SelectMany(order =>
                        from lineItem1 in order.OrderDetails
                        from lineItem2 in order.OrderDetails
                        select new ProductCobought
                        {
                            ProductId = (uint)lineItem1.ProductId,
                            CoboughtProductId = (uint)lineItem2.ProductId
                        })
                        .Where(p => p.ProductId != p.CoboughtProductId)
                        .GroupBy(p => new { p.ProductId, p.CoboughtProductId })
                        .Select(p => p.FirstOrDefault())
                        .OrderBy(p => p.ProductId)
                        .ThenBy(p => p.CoboughtProductId);

                var datasetFile = System.IO.File.CreateText(path: GetDataPath($"{country.ToLower()}-{DatasetName}"));

                datasetFile.WriteLine("ProductID\tCoboughtProductID");
                foreach (var item in coboughtProducts)
                {
                    datasetFile.WriteLine("{0}\t{1}", item.ProductId, item.CoboughtProductId);
                }
                datasetFile.Close();
            }

            var model = CreateHomeIndexViewModel();
            return View("Index", model);
        }

        public IActionResult TrainModels()
        {
            var stopWatch = Stopwatch.StartNew();
            foreach (string country in Countries)
            {
                var mlContext = new MLContext();
                IDataView dataView = mlContext.Data.LoadFromTextFile(
                    path: GetDataPath($"{country}-{DatasetName}"),
                    columns: new[]
                    {
                        new TextLoader.Column(name: "Label", dataKind: DataKind.Double, index: 0),
                        new TextLoader.Column(name: nameof(ProductCobought.ProductId), dataKind: DataKind.UInt32, source: new [] { new TextLoader.Range(0) }, keyCount: new KeyCount(77)),
                        new TextLoader.Column(name: nameof(ProductCobought.CoboughtProductId), dataKind: DataKind.UInt32, source: new [] { new TextLoader.Range(1) }, keyCount: new KeyCount(77))
                    },
                    hasHeader: true,
                    separatorChar: '\t');

                var options = new MatrixFactorizationTrainer.Options
                {
                    MatrixColumnIndexColumnName = nameof(ProductCobought.ProductId),
                    MatrixRowIndexColumnName = nameof(ProductCobought.CoboughtProductId),
                    LabelColumnName = "Label",
                    LossFunction = MatrixFactorizationTrainer.LossFunctionType.SquareLossOneClass,
                    Alpha = 0.01,
                    Lambda = 0.025,
                    C = 0.00001
                };

                MatrixFactorizationTrainer mft = mlContext.Recommendation().Trainers.MatrixFactorization(options);
                ITransformer trainedModel = mft.Fit(dataView);
                mlContext.Model.Save(trainedModel, inputSchema: dataView.Schema, filePath: GetDataPath($"{country}-model.zip"));
            }

            stopWatch.Stop();

            var model = CreateHomeIndexViewModel();
            model.Milliseconds = stopWatch.ElapsedMilliseconds;
            return View("Index", model);
        }

        public IActionResult Cart(int? id)
        {
            string? cartCookie = Request.Cookies["nw_cart"] ?? string.Empty;
            if (id.HasValue)
            {
                if (string.IsNullOrWhiteSpace(cartCookie))
                {
                    cartCookie = id.ToString();
                }
                else
                {
                    string[] ids = cartCookie.Split('-');
                    if (!ids.Contains(id.ToString()))
                    {
                        cartCookie = string.Join('-', cartCookie, id.ToString());
                    }
                }

                Response.Cookies.Append("nw_cart", cartCookie);
            }

            var model = new HomeCartViewModel
            {
                Cart = new Cart
                {
                    Items = Enumerable.Empty<CartItem>()
                },
                Recommendations = new List<EnrichedRecommendation>()
            };
            if (cartCookie.Length > 0)
            {
                model.Cart.Items = cartCookie
                    .Split('-')
                    .Select(item => new CartItem
                    {
                        ProductId = long.Parse(item),
                        ProductName = _db.Products.Find(long.Parse(item)).ProductName
                    });
            }

            if (System.IO.File.Exists(GetDataPath("germany-model.zip")))
            {
                var mlContext = new MLContext();
                ITransformer modelGermany;
                using (var stream = new FileStream(
                    path: GetDataPath("germany-model.zip"),
                    mode: FileMode.Open,
                    access: FileAccess.Read,
                    share: FileShare.Read))
                {
                    modelGermany = mlContext.Model.Load(stream, out DataViewSchema schema);
                }

                using var predictionEngine = mlContext.Model.CreatePredictionEngine<ProductCobought, Recommendation>(modelGermany);
                var products = _db.Products.ToArray();
                foreach (var item in model.Cart.Items)
                {
                    var topThree = products
                        .Select(product => predictionEngine
                            .Predict(new ProductCobought
                            {
                                ProductId = (uint)item.ProductId,
                                CoboughtProductId = (uint)product.ProductId
                            })
                        )
                        .OrderByDescending(x => x.Score).Take(3)
                        .ToArray();

                    model.Recommendations
                        .AddRange(topThree
                            .Select(rec => new EnrichedRecommendation
                            {
                                CoboughtProductID = rec.CoboughtProductID,
                                Score = rec.Score,
                                ProductName = _db.Products.Find((long)rec.CoboughtProductID).ProductName
                            }
                            ));
                }

                model.Recommendations = model.Recommendations
                    .OrderByDescending(rec => rec.Score)
                    .Take(3)
                    .ToList();
            }

            return View(model);
        }

        private string GetDataPath(string file)
        {
            return Path.Combine(_env.ContentRootPath, file);
        }

        private HomeIndexViewModel CreateHomeIndexViewModel()
            => new()
        {
            Categories = _db.Categories.Include(category => category.Products),
            GermanyDatasetExists = System.IO.File.Exists(GetDataPath("germany-dataset.txt")),
            UKDatasetExists = System.IO.File.Exists(GetDataPath("uk-dataset.txt")),
            USADatasetExists = System.IO.File.Exists(GetDataPath("usa-dataset.txt"))
        };
    }
}