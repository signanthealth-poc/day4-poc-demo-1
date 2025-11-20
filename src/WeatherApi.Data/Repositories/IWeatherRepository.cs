using WeatherApi.Core.Models;

namespace WeatherApi.Data.Repositories;

/// <summary>
/// Interface for weather data repository operations
/// </summary>
public interface IWeatherRepository
{
    /// <summary>
    /// Logs a weather request for statistics
    /// </summary>
    /// <param name="city">The city that was requested</param>
    Task LogWeatherRequestAsync(string city);

    /// <summary>
    /// Gets weather statistics from logged requests
    /// </summary>
    /// <returns>Weather statistics</returns>
    Task<WeatherStats> GetWeatherStatsAsync();
}