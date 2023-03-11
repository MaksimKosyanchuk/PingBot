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

        static void Main(string[] args)
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
            if (Message.Contains("/ping"))
            {
                if (Message == "/ping_everyone" || Message == $"/ping_everyone@{BotLogin}")
                    PingAll.Ping(botClient, update.Message);

                else if (Message.Split(" ").Length != 2)
                    text = MyStrings.Errors.ArgumentsCount;

                else
                    try
                    {
                        text = PingCategory.Handler(Message, update.Message.Chat.Id);
                    }
                    catch (Exception ex)
                    {
                        text = ex.Message;
                    }
            }
            else if (Message.Contains("/add_category") || Message.Contains($"/add_category@{BotLogin}"))
            {
                text = AddCategory.Handler(Message, update.Message.Chat.Id);
            }

            else if (Message.Contains("/remove_category") || Message.Contains($"/remove_category@{BotLogin}"))
                try
                {
                    text = RemoveCategory.Remove(Message, update.Message.Chat.Id);
                }
                catch (Exception ex)
                {
                    text = ex.Message;
                }
            else if (Message == "/help" || Message == "/help@Maks28925_bot")
                text = Help();

            else if (Message == "/get_categories" || Message == $"/get_categories@{BotLogin}")
                text = GetAllCategories.GetCategories(update.Message.Chat.Id);

            if (text != "")
                await botClient.SendTextMessageAsync(update.Message.Chat.Id, text);

        }

        private static string Help() => MyStrings.GetHelpStr;
        
        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3) => throw new NotImplementedException();
    }
}
