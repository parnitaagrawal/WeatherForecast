using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using WeatherForecast.Application.Contracts;
using WeatherForecast.Application.Services;
using WeatherForecast.Domain.Entitites;
using WeatherForecast.Domain.Exceptions;
using WeatherForecast.Domain.Repositories;
using Xunit;
using System.Collections.Generic;


namespace WeatherApplication.Tests
{
    public class WeatherForecastServiceTests
    {
        Mock<IWeatherForecastRepository> forecastRepository;
        public WeatherForecastServiceTests()
        {
            forecastRepository = new Mock<IWeatherForecastRepository>()
            {
                CallBase = true
            };
        }
        [Fact]
        public async void AddWeatherForecast_ForecastDateIsLessThanTodaysDate_ThrowForecastDateCannotBeInPastException()
        {
            //ARRANGE

            var resultToReturn = MockedEntity.mockedWeatherForecasts;
            var request = MockedEntity.mockedWeatherForecastErrorDto;

            forecastRepository.Setup(x => x.AddWeatherForecastAsync(It.IsAny<WeatherForecasts>())).ReturnsAsync(resultToReturn);
            var service = new WeatherForecastService(forecastRepository.Object);

           
            //ACT
            var func = new Func<Task>(async () => await service.AddWeatherForecastAsync(request));

            //ASSERT
           await func.Should().ThrowAsync<ForecastDateCannotBeInPastException>()
                 .WithMessage("The forecast date cannot be in past");
            
        }

        [Fact]
        public async void AddWeatherForecast_TemperatureInCelsiusIsNotBetweenPlusAndMinus60_ThrowTemperatureShouldBeBetweenPlusMinus60Exception()
        {
            //ARRANGE

            var resultToReturn = MockedEntity.mockedWeatherForecasts;
            var request = MockedEntity.mockedWeatherForecastErrorDto;
            request.ForecastDate = DateTime.Now;
            

            forecastRepository.Setup(x => x.AddWeatherForecastAsync(It.IsAny<WeatherForecasts>())).ReturnsAsync(resultToReturn);
            var service = new WeatherForecastService(forecastRepository.Object);


            //ACT
            var func = new Func<Task>(async () => await service.AddWeatherForecastAsync(request));

            //ASSERT
            await func.Should().ThrowAsync<TemperatureShouldBeBetweenPlusMinus60>()
                  .WithMessage("Temperature must be between -60 and +60 degrees Celsius");

        }

        [Fact]
        public async void AddWeatherForecast_CorrectRequestDto_ReturnMappedDto()
        {
            //ARRANGE

            var resultToReturn = MockedEntity.mockedWeatherForecasts;
            var request = MockedEntity.mockedWeatherForecastDto;


            forecastRepository.Setup(x => x.AddWeatherForecastAsync(It.IsAny<WeatherForecasts>())).ReturnsAsync(resultToReturn);
            var service = new WeatherForecastService(forecastRepository.Object);


            //ACT
            var result = await service.AddWeatherForecastAsync(request);

            //ASSERT
            result.Should().NotBeNull();
            result.Should().BeOfType<WeatherForecastDto>();            
            result.WeatherCondition.Should().Be(request.WeatherCondition);
            result.TemperatureInCelsius.Should().Be(request.TemperatureInCelsius);
        }

        [Fact]
        public async void GetWeeklyWeatherForecast_CorrectStartDate_ReturnsCollectionOfForecast()
        {
            //ARRANGE

            var resultToReturn = MockedEntity.listmockedWeatherForecast;
            var request = DateTime.Now;

            forecastRepository.Setup(x => x.GetWeeklyWeatherForecastAsync(It.IsAny<DateTime>(),It.IsAny<DateTime>())).ReturnsAsync(resultToReturn);
            var service = new WeatherForecastService(forecastRepository.Object);


            //ACT
            var result = await service.GetWeeklyWeatherForecastAsync(request);

            //ASSERT
            result.Should().NotBeEmpty().And.HaveCount(1);
            
        }
    }
}