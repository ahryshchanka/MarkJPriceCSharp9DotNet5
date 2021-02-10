using System;
using System.Linq;
using System.Threading.Tasks;

namespace MarkJPriceCSharp9DotNet5.Ch20.Data
{
    public class WeatherForecastService
    {
        private readonly Random _rng = new();

        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            return Task.FromResult(Enumerable
                .Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = startDate.AddDays(index),
                    TemperatureC = _rng.Next(-20, 55),
                    Summary = Summaries[_rng.Next(Summaries.Length)]
                })
                .ToArray());
        }
    }
}