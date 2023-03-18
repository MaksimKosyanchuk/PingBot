using System;
using System.Threading.Tasks;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Khai518Bot.Bot.Commands;

namespace PingBot
{
    internal class Program
    {
        public static string BotLogin;
        public static TelegramBotClient Client;
        private static readonly Dictionary<CommandAttribute, Type> _commands = new();
        public static CommandFactory _commandFactory;

        static void Main()
        {
            var token = JsonHandler.GetBotToken();
            Client = new TelegramBotClient(token);
            Client.StartReceiving(Update, Error);
            BotLogin = Client.GetMeAsync().Result.Username;
            _commandFactory = new CommandFactory(Client);
            JsonHandler.Starter(new Update());
            Logger.Logger.Starter();
            while (true)
            {
                Task.Delay(5);
            }
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            foreach (var command in _commandFactory.CreateCommands(update))
            {
                await command.Execute(update, botClient);
            }
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3) => throw new NotImplementedException();
    }
}
