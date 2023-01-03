using System;
using System.Threading.Tasks;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.ComponentModel.Design;
using System.Linq;
using Newtonsoft.Json.Linq;
using static PingBot.CattegoryClass;
using Telegram.Bot.Types.Enums;

namespace PingBot
{
    internal class Program : PingAll
    {
        public static Dictionary<string, CattegoryClass.Cattegory> AllCattegoryes = new Dictionary<string, CattegoryClass.Cattegory>();
        public static TelegramBotClient BotClient;
        public static Update NewUpdate;

        static void Main(string[] args)
        {
            var client = new TelegramBotClient("5634953591:AAEWzLkitszQUtwfbizqerd2Y5cwGPlQh2o");
            client.StartReceiving(Update, Error);
            BotClient = client; 
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            NewUpdate = update;
            if (update.Type == UpdateType.Message)
            {
                CheckCommand(update);
            }
        }

        public async static void PushText(string text)
        {
            await BotClient.SendTextMessageAsync(NewUpdate.Message.Chat.Id, text);
        }

        private static void CheckCommand(Update update)
        {
            if (update.Message.Text.Contains("/ping"))
            {
                string[] userCommand = update.Message.Text.Split(" ");
                if (update.Message.Text.Contains("/ping_everyone") || update.Message.Text.Contains("/ping_everyone@Maks28925_bot"))
                {
                    PingAll.Ping(BotClient, NewUpdate.Message);
                }
                else if (userCommand.Length != 2)
                {
                    PushText("Error: недостаточно аргументов!");
                    return;
                }
                else
                {
                    PingCattegory.Handler(update.Message.Text);
                }
            }
            else if (update.Message.Text.Contains("/add_cattegory"))
            {
                AddCattegory.Handler(update.Message.Text);
            }
            else if (update.Message.Text.Contains("/remove_cattegory"))
            {
                RemoveCattegory.Remove();
            }
            else if (update.Message.Text == "/help" || update.Message.Text == "/help@Maks28925_bot")
                {
                    Help();
                }
            else if (update.Message.Text == "/get_cattegoryes" || update.Message.Text == "/get_cattegoryes@Maks28925_bot")
            {
                GetAllCattegoryes();
            }
        }

        private static void GetAllCattegoryes()
        {
            string text = "Вот все категории:\n";
            string[] cattegoryes = AllCattegoryes.Keys.ToArray();
            if (cattegoryes.Length == 0)
            {
                PushText("Ни одной категории нет!");
                return;
            }
            int i = 0;
            foreach (var cattegory in AllCattegoryes)
            {
                if (cattegory.Value.ChatId == NewUpdate.Message.Chat.Id)
                {
                    text += (i+1).ToString() + ": " + cattegoryes[i] + "\n";
                    i++;
                }
            }
            PushText(text);
        }


        private static void Help()
        {
            PushText("/ping [cattegory] - to ping cattegory\n/ping_all - to ping_all\n/add_cattegory [cattegory_name] [@people] - to added cattegory");
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }
    }
}
