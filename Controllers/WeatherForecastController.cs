using Microsoft.AspNetCore.Mvc;

namespace API_GIT.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
           
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration    )
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        // [ActionName("Get")]
         [Route("[controller]/Get")]



        public IEnumerable<WeatherForecast> Get()
        {
            var key = _configuration["Tag_log"];

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Environment = "Ambiente:" + key
            })
            .ToArray();
        }


        [HttpGet]
        //  [ActionName("GetProducts")]
        [Route("[controller]/GetProducts")]

        public IEnumerable<WeatherForecast> GetProducts()
        {
            var key = _configuration["Tag_log"];

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Environment = "API-CAMBIOS-WCJ :" + key
            })
            .ToArray();
        }

    }
}