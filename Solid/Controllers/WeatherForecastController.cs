using Microsoft.AspNetCore.Mvc;

namespace Solid.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("OpenClose")]
    public decimal OpenClose()
    {
        var openclose = new Invoice();
        return openclose.GetTotal(new List<IDrink>{
            new Alcohol{Name="Beer", Promo = 0.2m, Price=3, Invoice=0.1m },
            new Energizing{Name="Monster", Price=7, Invoice=0.1m, Expiration= 1 },
            new Sugary{Name="Fanta", Price=13, Invoice=0.1m, Expiration= 1 },
            new Water{Name="Water", Price=2, Invoice=0.1m }
        });
    }
}
