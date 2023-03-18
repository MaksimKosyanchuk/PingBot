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
        private static CommandFactory _commandFactory;

        static void Main()
        {
            var token = JsonHandler.GetBotToken();
            Client = new TelegramBotClient(token);
            Client.StartReceiving(Update, Error);
            BotLogin = Client.GetMeAsync().Result.Username;
            JsonHandler.Starter();
            _commandFactory = new CommandFactory(Client);
            while (true)
            {
                Task.Delay(5);
            }
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
           
            foreach (var command in _commandFactory.CreateCommands(update))
                await command.Execute(update, botClient);
        }

        private async static Task CheckCommand(ITelegramBotClient botClient, Update update)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var classesWithAttribute = assembly.GetTypes()
                                                .Where(type => type
                                                .GetCustomAttributes(
                                                typeof(CommandAttribute), 
                                                true).Any());

            foreach (var classWithAttribute in classesWithAttribute)
            {
                Console.WriteLine(classWithAttribute.Name);
            }
            await JsonHandler.GetJsonObj();
        }

        private static void CommandsInit()
        {
            var commandTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Command)) && !t.IsAbstract);

            foreach (var type in commandTypes)
            {
                var attribute = type.GetCustomAttribute<CommandAttribute>();
                if (attribute != null)
                {
                    _commands.Add(attribute, type);
                }

            }
        }
        private static bool CheckCorrectCommand(string[] arr) => Strings.Commands.AllCategory
                                                    .Contains(arr[0].Replace("@" + BotLogin, ""));
       
        private static string Help() => Strings.GetHelpStr;
        
        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3) => throw new NotImplementedException();
    }
}
