using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using WeatherForecast.Domain;

namespace WeatherForecast.Application.Contracts
{
    public class CreateWeatherForecastDto
    {
        public DateTime ForecastDate { get; set; }
        public int TemperatureInCelsius { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public WeatherSummary WeatherCondition { get; set; }
    }
}
