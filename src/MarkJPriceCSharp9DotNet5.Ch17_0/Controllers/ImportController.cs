using MarkJPriceCSharp9DotNet5.Ch17_0.Entities;
using MarkJPriceCSharp9DotNet5.Ch17_0.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Piranha;
using Piranha.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MarkJPriceCSharp9DotNet5.Ch17_0.Controllers
{
    public class ImportController : Controller
    {
        private readonly IApi _api;
        private readonly Northwind _db;

        public ImportController(IApi api, Northwind db)
        {
            _api = api;
            _db = db;
        }

        [Route("/import")]
        public async Task<IActionResult> Import()
        {
            int importCount = 0;
            int existCount = 0;

            var site = await _api.Sites.GetDefaultAsync();
            var catalog = await _api.Pages.GetBySlugAsync<CatalogPage>("catalog");

            await foreach (Category c in _db.Categories.Include(c => c.Products).AsAsyncEnumerable())
            {
                var categoryPage = await _api.Pages.GetBySlugAsync<CategoryPage>($"catalog/{c.CategoryName.ToLower().Replace(' ', '-') }");

                if (categoryPage == null)
                {
                    importCount++;
                    categoryPage = await CategoryPage.CreateAsync(_api);

                    categoryPage.Id = Guid.NewGuid();
                    categoryPage.SiteId = site.Id;
                    categoryPage.ParentId = catalog.Id;
                    categoryPage.CategoryDetail.CategoryId = (int)c.CategoryId;
                    categoryPage.CategoryDetail.CategoryName = c.CategoryName;
                    categoryPage.CategoryDetail.Description = c.Description;

                    var folders = await _api.Media.GetAllFoldersAsync();
                    var categoriesFolderId = folders.First(folder => folder.Name == "Categories").Id;

                    var byFolder = await _api.Media.GetAllByFolderIdAsync(categoriesFolderId);
                    var image = byFolder.FirstOrDefault(media => media.Type == MediaType.Image && media.Filename == $"category{c.CategoryId}.jpeg");

                    categoryPage.CategoryDetail.CategoryImage = image ?? categoryPage.CategoryDetail.CategoryImage;

                    if (categoryPage.Products.Count == 0)
                    {
                        categoryPage.Products = c.Products
                            .Select(p => new ProductRegion
                            {
                                ProductId = (int)p.ProductId,
                                ProductName = p.ProductName,
                                UnitPrice = p.Cost.ToString("c"),
                                UnitsInStock = (int)p.Stock
                            }).ToList();
                    }

                    categoryPage.Title = c.CategoryName;
                    categoryPage.MetaDescription = c.Description;
                    categoryPage.NavigationTitle = c.CategoryName;
                    categoryPage.Published = DateTime.Now;
                    await _api.Pages.SaveAsync(categoryPage);
                }
                else
                {
                    existCount++;
                }
            }

            TempData["import_message"] = $"{existCount} categories already existed. {importCount} new categories imported.";

            return Redirect("~/");
        }
    }
}