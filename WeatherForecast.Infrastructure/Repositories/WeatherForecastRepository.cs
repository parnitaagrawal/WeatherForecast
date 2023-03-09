using WeatherForecast.Domain.Entitites;
using WeatherForecast.Domain.Repositories;

namespace WeatherForecast.Infrastructure.Repositories
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public WeatherForecastRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<WeatherForecasts> AddWeatherForecastAsync(WeatherForecasts weatherForecast)
        {
            await _dbContext.WeatherForecasts.AddAsync(weatherForecast);
            await _dbContext.SaveChangesAsync();
            return weatherForecast;
        }

        public async Task<IEnumerable<WeatherForecasts>> GetWeeklyWeatherForecastAsync(DateTime startDate, DateTime endOfWeek)
        {
            return _dbContext.WeatherForecasts.Where(f => f.ForecastDate >= startDate && f.ForecastDate < endOfWeek);
        }
    }
}
