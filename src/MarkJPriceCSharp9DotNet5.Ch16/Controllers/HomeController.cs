using MarkJPriceCSharp9DotNet5.Ch16.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MarkJPriceCSharp9DotNet5.Ch16.Controllers
{
    public class HomeController : Controller
    {
        private readonly Northwind _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(Northwind db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index() => View();

        public async Task<IActionResult> Products(CancellationToken cancellationToken)
        {
            var result = await _db
                .Products
                .AsNoTracking()
                .ToArrayAsync(cancellationToken);

            return View(result);
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}