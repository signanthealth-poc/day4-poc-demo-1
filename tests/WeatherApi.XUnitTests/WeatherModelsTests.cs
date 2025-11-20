using WeatherApi.Core.Models;
using Xunit;

namespace WeatherApi.XUnitTests;

public class WeatherModelsTests
{
    [Fact]
    public void WeatherForecast_TemperatureF_ShouldCalculateCorrectly()
    {
        // Arrange
        var forecast = new WeatherForecast { TemperatureC = 0 };

        // Act
        var fahrenheit = forecast.TemperatureF;

        // Assert
        Assert.Equal(32, fahrenheit);
    }

    [Theory]
    [InlineData(-10, 14)]
    [InlineData(0, 32)]
    [InlineData(10, 50)]
    [InlineData(20, 68)]
    [InlineData(30, 86)]
    public void WeatherForecast_TemperatureF_ShouldConvertCorrectly(int celsius, int expectedFahrenheit)
    {
        // Arrange
        var forecast = new WeatherForecast { TemperatureC = celsius };

        // Act
        var fahrenheit = forecast.TemperatureF;

        // Assert
        Assert.Equal(expectedFahrenheit, fahrenheit);
    }

    [Fact]
    public void WeatherForecast_ShouldInitialize_WithDefaultValues()
    {
        // Act
        var forecast = new WeatherForecast();

        // Assert
        Assert.Equal(default(DateOnly), forecast.Date);
        Assert.Equal(0, forecast.TemperatureC);
        Assert.Equal(32, forecast.TemperatureF); // 0°C = 32°F
        Assert.Null(forecast.Summary);
        Assert.Equal(string.Empty, forecast.City);
        Assert.Equal(0, forecast.Humidity);
        Assert.Equal(0, forecast.WindSpeed);
    }

    [Fact]
    public void WeatherInfo_ShouldInitialize_WithDefaultValues()
    {
        // Act
        var info = new WeatherInfo();

        // Assert
        Assert.Equal(string.Empty, info.City);
        Assert.Equal(0, info.Temperature);
        Assert.Equal(string.Empty, info.Condition);
        Assert.Equal(0, info.Humidity);
        Assert.Equal(0, info.WindSpeed);
        Assert.Equal(0, info.Pressure);
        Assert.Equal(default(DateTime), info.Timestamp);
    }

    [Fact]
    public void WeatherStats_ShouldInitialize_WithDefaultValues()
    {
        // Act
        var stats = new WeatherStats();

        // Assert
        Assert.Equal(0, stats.TotalRequests);
        Assert.Equal(0, stats.AverageTemperature);
        Assert.Equal(string.Empty, stats.MostRequestedCity);
        Assert.Equal(default(DateTime), stats.LastUpdated);
    }
}