using System;
using System.Threading.Tasks;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Collections.Generic;
using Telegram.Bot.Types.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace PingBot
{
    internal class Program
    {
        public static Dictionary<string, CattegoryClass.Cattegory> AllCattegoryes = new Dictionary<string, CattegoryClass.Cattegory>();
        public static TelegramBotClient BotClient;

        static void Main(string[] args)
        {
            var client = new TelegramBotClient("5634953591:AAEWzLkitszQUtwfbizqerd2Y5cwGPlQh2o");
            client.StartReceiving(Update, Error);
            BotClient = client; 
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            if (update.Type == UpdateType.Message && update.Message.Text != null)
            {
                await CheckCommand(botClient, update);
            }
        }

        private async static Task CheckCommand(ITelegramBotClient botClient, Update update)
        {
            string text = "";
            if (update.Message.Text.Contains("/ping"))
            {
                string[] userCommand = update.Message.Text.Split(" ");
                if (update.Message.Text == "/ping_everyone" || update.Message.Text == "/ping_everyone@Maks28925_bot")
                {
                    PingAll.Ping(botClient, update.Message);
                }
                else if (userCommand.Length != 2)
                {
                    text = "Error: недостаточно аргументов!";
                }
                else
                {
                    text = PingCattegory.Handler(update.Message.Text);
                }
            }
            else if (update.Message.Text.Contains("/add_cattegory") || update.Message.Text.Contains("/add_cattegory@Maks28925_bot"))
            {
                var countMembers = await BotClient.GetChatMemberCountAsync(update.Message.Chat.Id);
                text = AddCattegory.Handler(update.Message.Text, update, countMembers);
            }
            else if (update.Message.Text.Contains("/remove_cattegory") || update.Message.Text.Contains("/remove_cattegory@Maks28925_bot"))
            {
                text = RemoveCattegory.Remove(update);
            }
            else if (update.Message.Text == "/help" || update.Message.Text == "/help@Maks28925_bot")
            {
                text = Help();
            }
            else if (update.Message.Text == "/get_cattegories" || update.Message.Text == "/get_cattegories@Maks28925_bot")
            {
                text = GetAllCategories.GetCategories(update);
            }

            if (text != "")
            {
                await BotClient.SendTextMessageAsync(update.Message.Chat.Id, text);
            }
        }
        
        private static string Help()
        {
            return "/ping [cattegory] - to ping cattegory\n/ping_everyone- to ping_all\n/add_cattegory [cattegory_name] [@people] - to added cattegory\n/remove_cattegory [cattegory] - to delete cattegory\n/get_cattegories - to get all cattegories";
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}
