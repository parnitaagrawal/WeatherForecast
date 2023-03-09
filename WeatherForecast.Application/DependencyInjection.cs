using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Application.Middleware;
using WeatherForecast.Application.Services;
using WeatherForecast.Application.Services.Abstractions;

namespace WeatherForecast.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddScoped<IWeatherForecastService, WeatherForecastService>();
            services.AddSingleton<ExceptionHandlingMiddleware>();
            return services;
        }
    }
}
