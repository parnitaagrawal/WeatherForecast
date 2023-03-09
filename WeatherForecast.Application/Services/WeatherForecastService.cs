using Mapster;
using WeatherForecast.Application.Contracts;
using WeatherForecast.Application.Services.Abstractions;
using WeatherForecast.Domain.Entitites;
using WeatherForecast.Domain.Exceptions;
using WeatherForecast.Domain.Repositories;

namespace WeatherForecast.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<WeatherForecastDto> AddWeatherForecastAsync(WeatherForecastDto weatherForecastDto)
        {
            if (weatherForecastDto.ForecastDate < DateTime.Today)
            {
                throw new ForecastDateCannotBeInPastException();
            }

            if (weatherForecastDto.TemperatureInCelsius > 60 || weatherForecastDto.TemperatureInCelsius < -60)
            {
                throw new TemperatureShouldBeBetweenPlusMinus60();
            }

            var weatherForecast = weatherForecastDto.Adapt<WeatherForecasts>();

            await _weatherForecastRepository.AddWeatherForecastAsync(weatherForecast);
            return weatherForecast.Adapt<WeatherForecastDto>();
        }

        public async Task<IEnumerable<WeatherForecastDto>> GetWeeklyWeatherForecastAsync(DateTime startDate)
        {
            var endOfWeek = startDate.AddDays(7);
            var forecasts = await _weatherForecastRepository
                                  .GetWeeklyWeatherForecastAsync(startDate, endOfWeek);

            var forecastsDto = forecasts.Adapt<IEnumerable<WeatherForecastDto>>();

            return forecastsDto;
        }
    }
}
