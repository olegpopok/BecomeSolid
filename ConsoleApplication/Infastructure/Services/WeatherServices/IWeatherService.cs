using ConsoleApplication.Infastructure.Models.WeatherModels;

namespace ConsoleApplication.Infastructure.Services.WeatherServices
{
    public interface IWeatherService
    {
        Weather GetWeatherForCity(string city);
    }
}
