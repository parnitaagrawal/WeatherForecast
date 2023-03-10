using WeatherForecast.Application.Contracts;

namespace WeatherForecast.Application.Services.Abstractions
{
    public interface IWeatherForecastService
    {
        Task<IEnumerable<WeatherForecastDto>> GetWeeklyWeatherForecastAsync(DateTime startDate);

        Task<WeatherForecastDto> AddWeatherForecastAsync(CreateWeatherForecastDto weatherForecastDto);

    }
}
