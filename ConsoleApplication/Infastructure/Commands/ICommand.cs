using Telegram.Bot.Types;

namespace ConsoleApplication.Infastructure.Commands
{
    public interface ICommand
    {
        void Execute(Update update);
    }
}
