using Microsoft.AspNetCore.Mvc;

namespace firstApi.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
         
        private readonly ILogger<WeatherForecastController> _logger;
        private static List<WeatherForecast> _forecasts = new List<WeatherForecast>(Enumerable.Range(1, 5).Select(
            index => new WeatherForecast
            {
                Id = index,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecasts;
        }
        [HttpGet]
        public WeatherForecast? GetById(int id)
        {
            return _forecasts.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public string AddWeatherForecast(WeatherForecast forecast)
        {
            _forecasts.Add(forecast);
            return "success";


        }
        [HttpPut]
        public string UpdateWeatherForecast(WeatherForecast newforecast)
        {
            int index = _forecasts.FindIndex(x => x.Id == newforecast.Id);
            if (index != null)
            {
                _forecasts[index].Date = newforecast.Date;
                _forecasts[index].TemperatureC = newforecast.TemperatureC;
                _forecasts[index].Summary = newforecast.Summary;
            }
            return "success";
        }
        [HttpDelete]
        public string DeleteWeatherForecast(int id)
        {
            int index = _forecasts.FindIndex(x => x.Id == id);
            if (index != null)
            {
                _forecasts.RemoveAt(index);
            }
            return "success";
        }
    }
}