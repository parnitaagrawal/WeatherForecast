using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Domain.Repositories;
using WeatherForecast.Infrastructure.Repositories;

namespace WeatherForecast.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {

            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();
            return services;
        }
    }
}
