namespace WeatherForecast.Domain.Exceptions
{
    public class TemperatureShouldBeBetweenPlusMinus60 : BadRequestException
    {
        public TemperatureShouldBeBetweenPlusMinus60()
           : base($"Temperature must be between -60 and +60 degrees Celsius")
        {
        }
    }
}
