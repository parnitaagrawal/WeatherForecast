using WeatherForecast.Domain.Entitites;
namespace WeatherForecast.Domain.Repositories
{

    public interface IWeatherForecastRepository
    {
        Task<WeatherForecasts> AddWeatherForecastAsync(WeatherForecasts weatherForecast);

        Task<IEnumerable<WeatherForecasts>> GetWeeklyWeatherForecastAsync(DateTime startDate, DateTime endOfWeek);
    }

}
