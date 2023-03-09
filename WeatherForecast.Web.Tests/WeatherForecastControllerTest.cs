using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherForecast.API.Controllers;
using WeatherForecast.Application.Contracts;
using WeatherForecast.Application.Services.Abstractions;
using Xunit;

namespace WeatherForecast.API.Tests
{
    public class WeatherForecastControllerTest
    {
        Mock<IWeatherForecastService> forecastService;

        public WeatherForecastControllerTest()
        {
            forecastService = new Mock<IWeatherForecastService>
            {
                CallBase = true
            };
        }



        [Fact]
        public async void Get_WeeklyWeatherWithCorrectStartDate_OkResult()
        {
            //Arrange
            var startDate = DateTime.Now;

            var resultsToReturn = new List<WeatherForecastDto>()
            {
                MockedDTO.mockedWeatherForecastDto
            };

            forecastService.Setup(x => x.GetWeeklyWeatherForecastAsync(It.IsAny<DateTime>())).ReturnsAsync(resultsToReturn);

            var controller = new WeatherForecastController(forecastService.Object);

            //Act
            var result = await controller.GetWeatherForecastWeeklyAsync(startDate) as OkObjectResult;


            //ASSERT
            var response = (IEnumerable<WeatherForecastDto>)result.Value;
            result.Should().BeOfType<OkObjectResult>();
            result.Should().NotBeNull();
            response.Should().BeEquivalentTo(resultsToReturn);
        }

        [Fact]
        public async void Get_WeeklyWeatherWithEmptyObject_ThrowBadRequestException()
        {
            //Arrange
            var startDate = DateTime.Now;
            var resultsToReturn = new List<WeatherForecastDto>()
            {
                MockedDTO.mockedWeatherForecastDto
            };

            forecastService.Setup(x => x.GetWeeklyWeatherForecastAsync(It.IsAny<DateTime>())).ReturnsAsync(resultsToReturn);

            var controller = new WeatherForecastController(forecastService.Object);

           
            //ACT
            Task act() => controller.GetWeatherForecastWeeklyAsync(DateTime.MinValue);


            //ASSERT
            await Assert.ThrowsAsync<ApiException>(act);
        }

        [Fact]
        public async void Post_CreateWeatherForecastWithEmptyObject_ThrowsBadRequestException()
        {
            //Arrange
            var resultToReturn = MockedDTO.mockedWeatherForecastDto;

            forecastService.Setup(x => x.AddWeatherForecastAsync(It.IsAny<WeatherForecastDto>())).ReturnsAsync(resultToReturn);
            var controller = new WeatherForecastController(forecastService.Object);

            
            //ACT
            Task act() => controller.AddWeatherForecastAsync(null);


            //ASSERT
            await Assert.ThrowsAsync<ApiException>(act);

        }

        [Fact]
        public async void Post_CreateWeatherForecastWithCorrectObject_OkResult()
        {
            //ARRANGE


            var resultToReturn = MockedDTO.mockedWeatherForecastDto;

            forecastService.Setup(x => x.AddWeatherForecastAsync(It.IsAny<WeatherForecastDto>())).ReturnsAsync(resultToReturn);
            var controller = new WeatherForecastController(forecastService.Object);

            //ACT
            var result = await controller.AddWeatherForecastAsync(MockedDTO.mockedWeatherForecastDto) as OkObjectResult;


            //ASSERT
            var response = (WeatherForecastDto)result.Value;
            result.Should().BeOfType<OkObjectResult>();
            result.Should().NotBeNull();
            response.Should().BeEquivalentTo(resultToReturn);

        }
    }
}