using WeatherApi.Core.Models;

namespace WeatherApi.Core.Services;

/// <summary>
/// Interface for weather service operations
/// </summary>
public interface IWeatherService
{
    /// <summary>
    /// Gets weather forecast for the next 5 days
    /// </summary>
    /// <returns>A collection of weather forecasts</returns>
    Task<IEnumerable<WeatherForecast>> GetForecastAsync();

    /// <summary>
    /// Gets current weather for a specific city
    /// </summary>
    /// <param name="city">The city name</param>
    /// <returns>Current weather information</returns>
    Task<WeatherInfo?> GetCurrentWeatherAsync(string city);

    /// <summary>
    /// Gets weather statistics
    /// </summary>
    /// <returns>Weather statistics</returns>
    Task<WeatherStats> GetWeatherStatsAsync();
}