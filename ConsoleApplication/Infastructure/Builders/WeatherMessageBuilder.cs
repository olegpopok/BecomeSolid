
namespace ConsoleApplication.Infastructure.Builders
{
    public static class WeatherMessageBuilder
    {
        public static string Build(string cityName, string description, double temperature)
        {
            return "In " + cityName + " " + description + " and the temperature is " +
                           temperature.ToString("+#;-#") + "°C";
        }
    }
}
