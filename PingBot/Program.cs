using System;
using System.Threading.Tasks;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PingBot
{
    internal class Program
    {
        public static string BotLogin;

        static void Main()
        {
            var token = JsonHandler.GetBotToken();
            var client = new TelegramBotClient(token);
            client.StartReceiving(Update, Error);
            BotLogin = client.GetMeAsync().Result.Username;
            JsonHandler.Starter();
            while (true)
            {
                Task.Delay(5);
            }
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            if (update.Type == UpdateType.Message && update.Message.Text != null)
                await CheckCommand(botClient, update);
        }

        private async static Task CheckCommand(ITelegramBotClient botClient, Update update)
        {
            string text = "";
            string Message = update.Message.Text;
            long ChatId = update.Message.Chat.Id;
            string[] arr = Message.Split(" ");
            if (!CheckCorrectCommand(arr))
                return;
            try
            {
                switch (arr[0].Replace("@" + BotLogin, ""))
                {
                    case MyStrings.Commands.Ping:
                        text = PingCategory.Handler(Message, ChatId);
                        break;
                    case MyStrings.Commands.PingEveryone:
                        PingAll.Ping(botClient, update.Message);
                        break;
                    case MyStrings.Commands.AddCategory:
                        text = AddCategory.Handler(Message, ChatId);
                        break;
                    case MyStrings.Commands.RemoveCategory:
                        text = RemoveCategory.Remove(Message, ChatId);
                        break;
                    case MyStrings.Commands.GetCategories:
                        text = GetAllCategories.GetCategories(ChatId);
                        break;
                    case MyStrings.Commands.Help:
                        text = Help();
                        break;
                }
            }
            catch (Exception e)
            {
                text = e.Message;
            }
            await botClient.SendTextMessageAsync(update.Message.Chat.Id, text);
        }

        private static bool CheckCorrectCommand(string[] arr) => MyStrings.Commands.AllCategory
                                                    .Contains(arr[0].Replace("@" + BotLogin, ""));
       
        private static string Help() => MyStrings.GetHelpStr;
        
        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3) => throw new NotImplementedException();
    }
}
