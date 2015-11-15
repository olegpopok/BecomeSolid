using System;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace ConsoleApplication.Infastructure.Commands
{
    public class EchoCommand : ICommand
    {
        private Api _bot;

        public EchoCommand(Api bot)
        {
            _bot = bot;
        }

        public async void Execute(Update update)
        {
            await _bot.SendChatAction(update.Message.Chat.Id, ChatAction.Typing);
            var t = await _bot.SendTextMessage(update.Message.Chat.Id, update.Message.Text);
            Console.WriteLine("Echo Message: {0}", update.Message.Text);
        }
    }
}
