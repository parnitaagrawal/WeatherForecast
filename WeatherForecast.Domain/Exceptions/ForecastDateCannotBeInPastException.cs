namespace WeatherForecast.Domain.Exceptions
{
    public class ForecastDateCannotBeInPastException : BadRequestException
    {
        public ForecastDateCannotBeInPastException()
           : base($"The forecast date cannot be in past")
        {
        }
    }
}
