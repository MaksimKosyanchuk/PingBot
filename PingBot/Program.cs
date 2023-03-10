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
        public static TelegramBotClient BotClient;
        public static string BotLogin;

        static async Task Main()
        {
            var token = Environment.GetEnvironmentVariable("token");
            var client = new TelegramBotClient(token);
            client.StartReceiving(Update, Error);
            BotClient = client;
            BotLogin = BotClient.GetMeAsync().Result.Username;
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
                        text = PingCattegory.Handler(Message, update.Message.Chat.Id);
                    }
                    catch (Exception ex)
                    {
                        text = ex.Message;
                    }
            }
            else if (Message.Contains("/add_cattegory") || Message.Contains($"/add_cattegory@{BotLogin}"))
            {
                text = AddCattegory.Handler(Message, update.Message.Chat.Id);
            }

            else if (Message.Contains("/remove_cattegory") || Message.Contains($"/remove_cattegory@{BotLogin}"))
                try
                {
                    text = RemoveCattegory.Remove(Message, update.Message.Chat.Id);
                }
                catch (Exception ex)
                {
                    text = ex.Message;
                }
            else if (Message == "/help" || Message == "/help@Maks28925_bot")
                text = Help();

            else if (Message == "/get_cattegories" || Message == $"/get_cattegories@{BotLogin}")
                text = GetAllCategories.GetCategories(update.Message.Chat.Id);

            if (text != "")
                await BotClient.SendTextMessageAsync(update.Message.Chat.Id, text);

        }

        private static string Help() => "help";

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3) => throw new NotImplementedException();
    }
}
