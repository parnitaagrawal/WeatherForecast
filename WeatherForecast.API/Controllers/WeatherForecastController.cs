using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Contracts;
using WeatherForecast.Application.Services.Abstractions;

namespace WeatherForecast.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(IWeatherForecastService weatherForecastService)
        {

            _weatherForecastService = weatherForecastService;
        }

        [HttpGet("GetWeatherWeekly")]
        public async Task<IActionResult> GetWeatherForecastWeeklyAsync(DateTime startDate)
        {
            if (startDate == DateTime.MinValue)
            {
                throw new ApiException("Start Date cannot be null");
            }

            var result = await _weatherForecastService.GetWeeklyWeatherForecastAsync(startDate);

            return Ok(result);
        }

        [HttpPost("AddWeatherForecast")]
        public async Task<IActionResult> AddWeatherForecastAsync(WeatherForecastDto weatherForecastDto)
        {
            if(weatherForecastDto == null)
            {
                throw new ApiException("request object cannot be null");
            }

            var result = await _weatherForecastService.AddWeatherForecastAsync(weatherForecastDto);

            return Ok(result);

        }
    }
}