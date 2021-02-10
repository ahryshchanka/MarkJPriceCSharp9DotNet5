using MarkJPriceCSharp9DotNet5.Ch12.Models;
using System.Linq;
using System.Threading.Tasks;

using static System.Console;

namespace MarkJPriceCSharp9DotNet5.Ch12
{
    static class Program
    {
        static async Task Main()
        {
            // await GroupJoinCategoriesAndProducts();
            await AggregateProducts();
        }

        private static async Task GroupJoinCategoriesAndProducts()
        {
            await using var db = new Northwind();

            var queryGroup = db
                .Categories
                .AsAsyncEnumerable()
                .GroupJoin(
                    inner: db.Products,
                    outerKeySelector: category => category.CategoryId,
                    innerKeySelector: product => product.CategoryId,
                    resultSelector: (category, matchingProducts) => new
                    {
                        Category = category.CategoryName,
                        Products = matchingProducts.OrderBy(p => p.ProductName).AsAsyncEnumerable()
                    }
                );

            await foreach (var item in queryGroup)
            {
                WriteLine("{0} has {1} products.", arg0: item.Category, arg1: item.Products.CountAsync());

                await foreach (var product in item.Products)
                {
                    WriteLine($" {product.ProductName}");
                }
            }
        }

        private static async Task AggregateProducts()
        {
            await using var db = new Northwind();

            WriteLine("{0,-25} {1,10}",
                arg0: "Product count:",
                arg1: db.Products.Count());
            WriteLine("{0,-25} {1,10:$#,##0.00}",
                arg0: "Highest product price:",
                arg1: db.Products.Max(p => p.Cost));
            WriteLine("{0,-25} {1,10:N0}",
                arg0: "Sum of units in stock:",
                arg1: db.Products.Sum(p => p.Stock));
            WriteLine("{0,-25} {1,10:N0}",
                arg0: "Sum of units on order:",
                arg1: db.Products.Sum(p => p.UnitsOnOrder));
            WriteLine("{0,-25} {1,10:$#,##0.00}",
                arg0: "Average unit price:",
                arg1: db.Products.Average(p => p.Cost));
            WriteLine("{0,-25} {1,10:$#,##0.00}",
                arg0: "Value of units in stock:",
                arg1: db.Products.AsEnumerable().Sum(p => p.Cost * p.Stock));
        }
    }
}