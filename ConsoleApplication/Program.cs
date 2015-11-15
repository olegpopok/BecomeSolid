using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication.DependencyInjection;
using Telegram.Bot.Types;
using Telegram.Bot;
using Newtonsoft.Json.Linq;
using ConsoleApplication.Infastructure.Commands;
using ConsoleApplication.Infastructure.Mappers;
using ConsoleApplication.Infastructure.Services;
using ConsoleApplication.Infastructure.Services.RateServices;
using ConsoleApplication.Infastructure.Services.WeatherServices;
using Ninject;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            MapperConfiguration.Configure();
            Run().Wait();
        }
        
        static async Task Run()
        {
            IKernel ninjectKernel = new StandardKernel(new DependencyConfiguration());

            var bot = ninjectKernel.Get<Api>();
            var me = await bot.GetMe();
            Console.WriteLine("Hello my name is {0}", me.Username);


            var commandServise = ninjectKernel.Get<CommandService>();
            var weatherCommand = ninjectKernel.Get<WeatherCommand>();
            commandServise.Add("/weather", weatherCommand);
            var offset = 0;
            

            while (true)
            {
                var updates = await bot.GetUpdates(offset);
                foreach (var update in updates)
                {
                    if (update.Message.Type == MessageType.TextMessage)
                    {
                        var commandName = update.Message.Text.Split(' ').First();
                        commandServise.GetByNameOrDefault(commandName).Execute(update);                          
                    }
                    offset = update.Id + 1;
                }
            }
        }
    }
}
