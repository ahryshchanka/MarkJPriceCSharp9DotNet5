using MarkJPriceCSharp9DotNet5.Ch11.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using static System.Console;

namespace MarkJPriceCSharp9DotNet5.Ch11
{
    static class Program
    {
        static async Task Main()
        {
            // await QueryingCategories(1);
            // await QueryingProducts();
            // await QueryingWithLike();

            if (await AddProduct(6, "Bob's Burgers", 500M))
            {
                WriteLine("Add product successful.");
            }
            await ListProducts();
        }

        private static async Task QueryingCategories(int stock)
        {
            await using var db = new Northwind();

            var loggerFactory = db.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(new LoggerProvider());

            WriteLine("Categories and how many products they have:");


            db.ChangeTracker.LazyLoadingEnabled = false;
            Write("Enable lazy loading? (Y/N): ");
            bool lazyLoading = (ReadKey().Key == ConsoleKey.Y);
            WriteLine();

            IAsyncEnumerable<Category> categories;
            if (lazyLoading)
            {
                categories = db
                    .Categories
                    .TagWith("Categories filtered by stock lazy.")
                    .Include(c => c.Products)
                    .AsNoTracking()
                    .AsAsyncEnumerable();
            }
            else
            {
                categories = db
                    .Categories
                    .TagWith("Categories filtered by stock.")
                    .Include(x => x.Products.Where(e => e.Stock >= stock))
                    .AsNoTracking()
                    .AsAsyncEnumerable() ?? AsyncEnumerable.Empty<Category>();
            }

            await foreach (var category in categories)
            {
                WriteLine($"{category.CategoryName} has {category.Products.Count} products with a minimum of {stock} units in stock.");

                foreach (Product product in category.Products)
                {
                    WriteLine($"\t{product.ProductName} has {product.Stock} units in stock.");
                }
            }
        }

        private static async Task QueryingProducts()
        {
            await using var db = new Northwind();

            var loggerFactory = db.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(new LoggerProvider());

            WriteLine("Products that cost more than a price, highest at top.");
            string input;
            decimal price;
            do
            {
                Write("Enter a product price: ");
                input = ReadLine();
            } while (!decimal.TryParse(input, out price));

            var products = db
                .Products
                .TagWith("Products filtered by price and sorted.")
                .AsAsyncEnumerable()
                .Where(product => product.Cost > price)
                .OrderByDescending(product => product.Cost) ?? AsyncEnumerable.Empty<Product>();

            await foreach (var product in products)
            {
                WriteLine($"{product.ProductId}: {product.ProductName} costs {product.Cost:$#,##0.00} and has {product.Stock} in stock.");
            }
        }

        private static async Task QueryingWithLike()
        {
            await using var db = new Northwind();

            var loggerFactory = db.GetService<ILoggerFactory>();
            loggerFactory.AddProvider(new LoggerProvider());

            Write("Enter part of a product name: ");
            var input = ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var products = db
                    .Products
                    .TagWith("Products filtered by like.")
                    .AsAsyncEnumerable()
                    .Where(p => p.ProductName != null && EF.Functions.Like(p.ProductName, $"%{input}%"));

                await foreach (Product product in products)
                {
                    WriteLine($"{product.ProductName} has {product.Stock} units in stock. Discontinued? {product.Discontinued}");
                }
            }
        }

        private static async Task<bool> AddProduct(int categoryId, string productName, decimal? price)
        {
            await using var db = new Northwind();

            var newProduct = new Product
            {
                CategoryId = categoryId,
                ProductName = productName,
                Cost = price
            };

            await db.Products.AddAsync(newProduct);
            int affected = await db.SaveChangesAsync();

            return affected == 1;
        }

        private static async Task ListProducts()
        {
            await using var db = new Northwind();

            var products = db.Products
                .AsAsyncEnumerable()
                .OrderByDescending(x => x.Cost);

            WriteLine($"{"ID",-3} {"Product Name",-35} {"Cost",8} {"Stock",5} {"Disc."}");
            await foreach (var product in products)
            {
                WriteLine($"{product.ProductId:000} {product.ProductName,-35} {product.Cost,8:$#,##0.00} {product.Stock,5} {product.Discontinued}");
            }
        }
    }
}