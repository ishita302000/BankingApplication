using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public List<string> Summaries = new List<String>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
            foreach(string summary in Summaries)
            {
                WeatherForecast weatherForecast = new WeatherForecast
                {
                    TemperatureC = 30,
                    Summary = summary
                };
                weatherForecasts.Add(weatherForecast);
            }
            return Ok(weatherForecasts);
        }

        [HttpPost]
        public IActionResult CreateNew(SummaryDTO s)
        {
            Summaries.Add(s.Summary);
            return Created(Request.Path, Summaries);
        }
    }
}
