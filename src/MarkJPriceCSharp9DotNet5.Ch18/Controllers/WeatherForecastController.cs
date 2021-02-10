using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkJPriceCSharp9DotNet5.Ch18.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        readonly Random _rng = new();

        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetByDays(int days)
            => Enumerable
                .Range(1, days)
                .Select(i => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = _rng.Next(-20, 55),
                    Summary = Summaries[_rng.Next(Summaries.Length)]
                })
                .ToArray();
    }
}