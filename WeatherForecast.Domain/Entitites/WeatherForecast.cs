namespace WeatherForecast.Domain.Entitites
{
    public class WeatherForecasts
    {
        public int Id { get; set; }
        public DateTime ForecastDate { get; set; }
        public int TemperatureInCelsius { get; set; }
        public WeatherSummary WeatherCondition { get; set; }
    }
}
