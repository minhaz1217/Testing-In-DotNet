using IntegrationTestingDummyApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationTestingDummyApp.Controllers
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
        private readonly IntegrationTestingDummyAppService _integrationTestingDummyAppService;


        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IntegrationTestingDummyAppService integrationTestingDummyAppService
            )
        {
            _logger = logger;
            _integrationTestingDummyAppService = integrationTestingDummyAppService; ;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet("get-value")]
        public IActionResult GetValue()
        {
            return Ok(_integrationTestingDummyAppService.GetValue());
        }
    }
}