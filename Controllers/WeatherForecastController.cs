using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;

        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }

    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("Get/WeatherForecast")]
    [Route("Get/WeatherForecast2")]
    [Route("[action]/WeatherForecast3")] // actions refers to the name of method
    public IEnumerable<WeatherForecast> GetW()
    {
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast w) {
        ListWeatherForecast.Add(w);
        return Created("/", w);
    }

    [HttpDelete("{index}/{g}")]
    public IActionResult DeleteWeatherForecast(int index)
    {
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}
