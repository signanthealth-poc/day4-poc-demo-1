using Microsoft.AspNetCore.Mvc;
using WeatherApi.Core.Models;
using WeatherApi.Core.Services;

namespace WeatherApi.Controllers;

/// <summary>
/// Weather API controller for managing weather forecasts
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;
    private readonly ILogger<WeatherController> _logger;

    public WeatherController(IWeatherService weatherService, ILogger<WeatherController> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    /// <summary>
    /// Gets weather forecast for the next 5 days
    /// </summary>
    /// <returns>A list of weather forecasts</returns>
    /// <response code="200">Returns the weather forecasts</response>
    [HttpGet("forecast")]
    [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), 200)]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> GetForecast()
    {
        _logger.LogInformation("Getting weather forecast");
        
        try
        {
            var forecasts = await _weatherService.GetForecastAsync();
            return Ok(forecasts);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting weather forecast");
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Gets current weather for a specific city
    /// </summary>
    /// <param name="city">The city name</param>
    /// <returns>Current weather information</returns>
    /// <response code="200">Returns the current weather</response>
    /// <response code="404">City not found</response>
    [HttpGet("current/{city}")]
    [ProducesResponseType(typeof(WeatherInfo), 200)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<WeatherInfo>> GetCurrentWeather(string city)
    {
        _logger.LogInformation("Getting current weather for city: {City}", city);
        
        if (string.IsNullOrWhiteSpace(city))
        {
            return BadRequest("City name is required");
        }

        try
        {
            var weather = await _weatherService.GetCurrentWeatherAsync(city);
            if (weather == null)
            {
                return NotFound($"Weather data not found for city: {city}");
            }
            
            return Ok(weather);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting current weather for city: {City}", city);
            return StatusCode(500, "Internal server error");
        }
    }

    /// <summary>
    /// Gets weather statistics
    /// </summary>
    /// <returns>Weather statistics information</returns>
    [HttpGet("stats")]
    [ProducesResponseType(typeof(WeatherStats), 200)]
    public async Task<ActionResult<WeatherStats>> GetWeatherStats()
    {
        _logger.LogInformation("Getting weather statistics");
        
        try
        {
            var stats = await _weatherService.GetWeatherStatsAsync();
            return Ok(stats);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting weather statistics");
            return StatusCode(500, "Internal server error");
        }
    }
}