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
                TemperatureC = Random.Shared.Next(-20, 55),
                Date = DateTime.Now.AddDays(index),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
        }

    }

    // [HttpGet(Name = "GetWeatherForecast")]
    // [Route("Get/WeatherForecast")] //we can have multiple routes for a request.
    // [Route("Get/WeatherForecast2")]
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        // _logger.LogWarning("Returning the list of weather forecast");
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast w) {
        ListWeatherForecast.Add(w);
        return Created("/", w);
    }

    [HttpDelete("{index}")]
    public IActionResult DeleteWeatherForecast(int index)
    {
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }
}
