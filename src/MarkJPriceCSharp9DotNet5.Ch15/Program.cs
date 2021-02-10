using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MarkJPriceCSharp9DotNet5.Ch15
{
    public static class Program
    {
        public static void Main()
        {
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .Build()
                .Run();
        }
    }
}