using MarkJPriceCSharp9DotNet5.Ch20.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkJPriceCSharp9DotNet5.Ch20.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly Random _rng = new();

        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
            => _logger = logger;

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
            => Enumerable
                .Range(1, 5)
                .Select(i => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(i),
                    TemperatureC = _rng.Next(-20, 55),
                    Summary = Summaries[_rng.Next(Summaries.Length)]
                })
                .ToArray();
    }
}