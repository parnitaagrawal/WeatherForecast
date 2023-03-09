using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Entitites;

namespace WeatherForecast.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<WeatherForecasts> WeatherForecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
