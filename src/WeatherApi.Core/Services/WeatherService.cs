using Microsoft.Extensions.Logging;
using WeatherApi.Core.Models;

namespace WeatherApi.Core.Services;

/// <summary>
/// Service for weather-related operations
/// </summary>
public class WeatherService : IWeatherService
{
    private readonly ILogger<WeatherService> _logger;

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static readonly string[] Cities = new[]
    {
        "New York", "London", "Tokyo", "Sydney", "Toronto", "Berlin", "Paris", "Rome", "Madrid", "Amsterdam"
    };

    public WeatherService(ILogger<WeatherService> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets weather forecast for the next 5 days
    /// </summary>
    public async Task<IEnumerable<WeatherForecast>> GetForecastAsync()
    {
        _logger.LogInformation("Generating weather forecast");

        var forecasts = Enumerable.Range(1, 5).Select(index =>
        {
            var random = new Random(index + DateTime.Now.Millisecond);
            return new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = random.Next(-20, 55),
                Summary = Summaries[random.Next(Summaries.Length)],
                City = Cities[random.Next(Cities.Length)],
                Humidity = random.Next(30, 90),
                WindSpeed = Math.Round(random.NextDouble() * 50, 1)
            };
        }).ToArray();

        // Simulate async operation
        await Task.Delay(100);

        return forecasts;
    }

    /// <summary>
    /// Gets current weather for a specific city
    /// </summary>
    public async Task<WeatherInfo?> GetCurrentWeatherAsync(string city)
    {
        _logger.LogInformation("Getting current weather for {City}", city);

        if (string.IsNullOrWhiteSpace(city))
        {
            return null;
        }

        // Simulate async operation
        await Task.Delay(50);

        var random = new Random(city.GetHashCode());
        var weather = new WeatherInfo
        {
            City = city,
            Temperature = random.Next(-10, 40),
            Condition = Summaries[random.Next(Summaries.Length)],
            Humidity = random.Next(30, 90),
            WindSpeed = Math.Round(random.NextDouble() * 30, 1),
            Pressure = Math.Round(random.NextDouble() * 50 + 980, 1),
            Timestamp = DateTime.UtcNow
        };

        return weather;
    }

    /// <summary>
    /// Gets weather statistics
    /// </summary>
    public async Task<WeatherStats> GetWeatherStatsAsync()
    {
        _logger.LogInformation("Getting weather statistics");

        // Simulate async operation
        await Task.Delay(10);

        return new WeatherStats
        {
            TotalRequests = new Random().Next(100, 1000),
            AverageTemperature = Math.Round(new Random().NextDouble() * 40 - 10, 1),
            MostRequestedCity = Cities[new Random().Next(Cities.Length)],
            LastUpdated = DateTime.UtcNow
        };
    }
}