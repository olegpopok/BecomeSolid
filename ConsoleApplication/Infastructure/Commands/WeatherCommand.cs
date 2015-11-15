using System;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using ConsoleApplication.Infastructure.Builders;
using ConsoleApplication.Infastructure.Services.WeatherServices;


namespace ConsoleApplication.Infastructure.Commands
{
    public class WeatherCommand : ICommand
    {
        private Api _bot;
        private IWeatherService _weatherService;

        public WeatherCommand(Api bot, IWeatherService weatherService)
        {
            _bot = bot;
            _weatherService = weatherService;
        }

        public async void Execute(Update update)
        {
            var city = GetCityFromMessage(update.Message.Text);
            var weather = _weatherService.GetWeatherForCity(city);
            var message = WeatherMessageBuilder.Build(weather.Name, weather.Description, weather.Temperature);
            await _bot.SendTextMessage(update.Message.Chat.Id, message);
            Console.WriteLine("Echo Message: {0}", message);
        }

        private string GetCityFromMessage(string message)
        {
            var messageParts = message.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var city = messageParts.Length == 1 ? "Minsk" : messageParts.Skip(1).First();
            return city;
        }
    }
}
