using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MarkJPriceCSharp9DotNet5.Ch17_0
{
    public static class Program
    {
        public static void Main()
            => Host
                .CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .Build()
                .Run();
    }
}