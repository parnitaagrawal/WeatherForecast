using System;
using WeatherForecast.Application.Contracts;

namespace WeatherForecast.API.Tests
{
    public class MockedDTO
    {
        public static WeatherForecastDto mockedWeatherForecastDto => new()
        {
            ForecastDate = DateTime.Now,
            TemperatureInCelsius = 20,
            WeatherCondition = Domain.WeatherSummary.Warm
        };

        public static CreateWeatherForecastDto createmockedWeatherForecastDto => new()
        {
            ForecastDate = DateTime.Now,
            TemperatureInCelsius = 20,
            WeatherCondition = Domain.WeatherSummary.Warm
        };
    }
}
