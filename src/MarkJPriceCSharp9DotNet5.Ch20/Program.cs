using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MarkJPriceCSharp9DotNet5.Ch20
{
    public static class Program
    {
        public static void Main(string[] args)
            => Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .Build()
                .Run();
    }
}