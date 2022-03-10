using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherMonitor.Dtos.Weather;
using WeatherMonitor.Services.Interfaces;


namespace WeatherMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService weatherForecastService)
        {
            _logger = logger;
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        /// <summary>
        /// Finds the current forecast based on the city
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{city}")]
        public async Task<IActionResult> GetWeatherForecast(string city)
        {
            var isMatch = Regex.IsMatch(city, @"[a-zA-Z]+\b$");
            if (!isMatch) throw new ApplicationException("Invalid input");

            var result = await _weatherForecastService.GetWeatherForecast(city);
            if (result == null) return BadRequest("No matching location found.");

            return Ok(result);
        }
    }
}
