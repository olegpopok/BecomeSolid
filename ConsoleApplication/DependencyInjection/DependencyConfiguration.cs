using ConsoleApplication.Infastructure.Commands;
using ConsoleApplication.Infastructure.Services.WeatherServices;
using Ninject.Modules;
using Telegram.Bot;

namespace ConsoleApplication.DependencyInjection
{
    public class DependencyConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<Api>().ToSelf().InSingletonScope().WithConstructorArgument("token", "155953405:AAHUNlCFI6DLGnEywj0D8Xu297E7a79lDUE");
            Bind<ICommand>().To<EchoCommand>();
            Bind<IWeatherService>().To<WeatherService>();
        }
    }
}
