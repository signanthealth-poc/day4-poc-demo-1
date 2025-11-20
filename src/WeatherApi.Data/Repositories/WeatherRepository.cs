using Microsoft.Extensions.Logging;
using WeatherApi.Core.Models;
using System.Collections.Concurrent;

namespace WeatherApi.Data.Repositories;

/// <summary>
/// In-memory implementation of weather repository for demo purposes
/// </summary>
public class WeatherRepository : IWeatherRepository
{
    private readonly ILogger<WeatherRepository> _logger;
    private static readonly ConcurrentDictionary<string, int> _cityRequests = new();
    private static int _totalRequests = 0;
    private static readonly object _lock = new();

    public WeatherRepository(ILogger<WeatherRepository> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Logs a weather request for statistics
    /// </summary>
    public async Task LogWeatherRequestAsync(string city)
    {
        _logger.LogDebug("Logging weather request for {City}", city);

        // Simulate async operation
        await Task.Delay(1);

        lock (_lock)
        {
            _cityRequests.AddOrUpdate(city, 1, (key, value) => value + 1);
            _totalRequests++;
        }
    }

    /// <summary>
    /// Gets weather statistics from logged requests
    /// </summary>
    public async Task<WeatherStats> GetWeatherStatsAsync()
    {
        _logger.LogDebug("Getting weather statistics");

        // Simulate async operation
        await Task.Delay(10);

        lock (_lock)
        {
            var mostRequestedCity = _cityRequests.OrderByDescending(kvp => kvp.Value)
                                                .FirstOrDefault().Key ?? "N/A";

            // Calculate average temperature based on city names (demo purposes)
            var averageTemp = _cityRequests.Keys.Select(city => 
                Math.Abs(city.GetHashCode() % 40) - 10).DefaultIfEmpty(0).Average();

            return new WeatherStats
            {
                TotalRequests = _totalRequests,
                AverageTemperature = Math.Round(averageTemp, 1),
                MostRequestedCity = mostRequestedCity,
                LastUpdated = DateTime.UtcNow
            };
        }
    }
}