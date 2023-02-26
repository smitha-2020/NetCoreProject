namespace project.services;
using project.Models;

public interface IWeatherForecastService
{
  IEnumerable<WeatherForecast> GetWeather(int days);
}