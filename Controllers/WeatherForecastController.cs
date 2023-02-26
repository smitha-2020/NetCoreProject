using Microsoft.AspNetCore.Mvc;
using project.Models;
using project.services;

namespace project.Controllers;

public class WeatherForecastController : ApiController
{
    private readonly ILogger<WeatherForecastController> _logger;
    //dependency injection for loose coupling use interface rather than service
    private readonly IWeatherForecastService _service;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
    {
        _logger = logger;
        _logger.LogInformation("This is the Constructor");
        _service = service;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
       return _service.GetWeather(3);
    }

    [HttpGet("{days}")]
    public IEnumerable<WeatherForecast> Get(int days)
    {
       return _service.GetWeather(days);
    }
}
