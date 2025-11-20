namespace WeatherApi.Core.Models;

/// <summary>
/// Represents a weather forecast for a specific date
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// Gets or sets the date of the forecast
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    /// Gets or sets the temperature in Celsius
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// Gets the temperature in Fahrenheit
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC * 9.0 / 5.0);

    /// <summary>
    /// Gets or sets the weather summary
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Gets or sets the city name
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the humidity percentage
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Gets or sets the wind speed in km/h
    /// </summary>
    public double WindSpeed { get; set; }
}

/// <summary>
/// Represents current weather information for a city
/// </summary>
public class WeatherInfo
{
    /// <summary>
    /// Gets or sets the city name
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current temperature in Celsius
    /// </summary>
    public int Temperature { get; set; }

    /// <summary>
    /// Gets or sets the weather condition
    /// </summary>
    public string Condition { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the humidity percentage
    /// </summary>
    public int Humidity { get; set; }

    /// <summary>
    /// Gets or sets the wind speed in km/h
    /// </summary>
    public double WindSpeed { get; set; }

    /// <summary>
    /// Gets or sets the atmospheric pressure in hPa
    /// </summary>
    public double Pressure { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when the data was recorded
    /// </summary>
    public DateTime Timestamp { get; set; }
}

/// <summary>
/// Represents weather statistics
/// </summary>
public class WeatherStats
{
    /// <summary>
    /// Gets or sets the total number of requests
    /// </summary>
    public int TotalRequests { get; set; }

    /// <summary>
    /// Gets or sets the average temperature
    /// </summary>
    public double AverageTemperature { get; set; }

    /// <summary>
    /// Gets or sets the most requested city
    /// </summary>
    public string MostRequestedCity { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the last updated timestamp
    /// </summary>
    public DateTime LastUpdated { get; set; }
}