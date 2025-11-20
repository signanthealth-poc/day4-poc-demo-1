using NUnit.Framework;
using WeatherApi.Core.Models;

namespace WeatherApi.NUnitTests;

[TestFixture]
public class WeatherModelsTests
{
    [Test]
    public void WeatherForecast_TemperatureF_ShouldCalculateCorrectly()
    {
        // Arrange
        var forecast = new WeatherForecast { TemperatureC = 0 };

        // Act
        var fahrenheit = forecast.TemperatureF;

        // Assert
        Assert.That(fahrenheit, Is.EqualTo(32));
    }

    [Test]
    public void WeatherForecast_ShouldInitialize_WithDefaultValues()
    {
        // Act
        var forecast = new WeatherForecast();

        // Assert
        Assert.That(forecast.Date, Is.EqualTo(default(DateOnly)));
        Assert.That(forecast.TemperatureC, Is.EqualTo(0));
        Assert.That(forecast.TemperatureF, Is.EqualTo(32)); // 0°C = 32°F
        Assert.That(forecast.Summary, Is.Null);
        Assert.That(forecast.City, Is.EqualTo(string.Empty));
        Assert.That(forecast.Humidity, Is.EqualTo(0));
        Assert.That(forecast.WindSpeed, Is.EqualTo(0));
    }

    [TestCase(-10, 14)]
    [TestCase(0, 32)]
    [TestCase(10, 50)]
    [TestCase(20, 68)]
    [TestCase(30, 86)]
    public void WeatherForecast_TemperatureF_ShouldConvertCorrectly(int celsius, int expectedFahrenheit)
    {
        // Arrange
        var forecast = new WeatherForecast { TemperatureC = celsius };

        // Act
        var fahrenheit = forecast.TemperatureF;

        // Assert
        Assert.That(fahrenheit, Is.EqualTo(expectedFahrenheit));
    }
}