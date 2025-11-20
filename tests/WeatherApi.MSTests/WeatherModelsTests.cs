using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherApi.Core.Models;

namespace WeatherApi.MSTests;

[TestClass]
public class WeatherModelsTests
{
    [TestMethod]
    public void WeatherForecast_TemperatureF_ShouldCalculateCorrectly()
    {
        // Arrange
        var forecast = new WeatherForecast { TemperatureC = 0 };

        // Act
        var fahrenheit = forecast.TemperatureF;

        // Assert
        Assert.AreEqual(32, fahrenheit);
    }

    [TestMethod]
    public void WeatherForecast_ShouldInitialize_WithDefaultValues()
    {
        // Act
        var forecast = new WeatherForecast();

        // Assert
        Assert.AreEqual(default(DateOnly), forecast.Date);
        Assert.AreEqual(0, forecast.TemperatureC);
        Assert.AreEqual(32, forecast.TemperatureF); // 0°C = 32°F
        Assert.IsNull(forecast.Summary);
        Assert.AreEqual(string.Empty, forecast.City);
        Assert.AreEqual(0, forecast.Humidity);
        Assert.AreEqual(0, forecast.WindSpeed);
    }

    [TestMethod]
    public void WeatherInfo_ShouldInitialize_WithDefaultValues()
    {
        // Act
        var info = new WeatherInfo();

        // Assert
        Assert.AreEqual(string.Empty, info.City);
        Assert.AreEqual(0, info.Temperature);
        Assert.AreEqual(string.Empty, info.Condition);
        Assert.AreEqual(0, info.Humidity);
        Assert.AreEqual(0, info.WindSpeed);
        Assert.AreEqual(0, info.Pressure);
        Assert.AreEqual(default(DateTime), info.Timestamp);
    }

    [TestMethod]
    public void WeatherStats_ShouldInitialize_WithDefaultValues()
    {
        // Act
        var stats = new WeatherStats();

        // Assert
        Assert.AreEqual(0, stats.TotalRequests);
        Assert.AreEqual(0, stats.AverageTemperature);
        Assert.AreEqual(string.Empty, stats.MostRequestedCity);
        Assert.AreEqual(default(DateTime), stats.LastUpdated);
    }
}