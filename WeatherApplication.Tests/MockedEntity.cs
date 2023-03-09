using System;
using System.Collections.Generic;
using WeatherForecast.Application.Contracts;
using WeatherForecast.Domain.Entitites;

namespace WeatherApplication.Tests
{
    public class MockedEntity
    {
        public static WeatherForecasts mockedWeatherForecasts => new()
        {
            Id = 1,
            ForecastDate = DateTime.Now,
            TemperatureInCelsius = 20,
            WeatherCondition = WeatherForecast.Domain.WeatherSummary.Warm
        };

        public static WeatherForecastDto mockedWeatherForecastErrorDto => new()
        {
            Id = 1,
            ForecastDate = DateTime.Now.AddDays(-1),
            TemperatureInCelsius = 70,
            WeatherCondition = WeatherForecast.Domain.WeatherSummary.Warm
        };

        public static WeatherForecastDto mockedWeatherForecastDto => new()
        {
            Id = 1,
            ForecastDate = DateTime.Now,
            TemperatureInCelsius = 30,
            WeatherCondition = WeatherForecast.Domain.WeatherSummary.Warm
        };

        public static List<WeatherForecasts> listmockedWeatherForecast => new()
        {
            new WeatherForecasts()
            {
                Id = 1,
                ForecastDate = DateTime.Now,
                TemperatureInCelsius = 30,
                WeatherCondition = WeatherForecast.Domain.WeatherSummary.Warm
            }
            
        };
    }
}
