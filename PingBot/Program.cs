﻿using System;
using System.Threading.Tasks;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Types;
using System.Collections.Generic;
using Telegram.Bot.Types.Enums;

namespace PingBot
{
    internal class Program
    {
        private static string HelpStr = "/ping [cattegory] - to ping cattegory\n/ping_everyone- to ping_all\n/add_cattegory [cattegory_name] [@people] - to added cattegory\n/remove_cattegory [cattegory] - to delete cattegory\n/get_cattegories - to get all cattegories";
        public static TelegramBotClient BotClient;

        static void Main()
        {
            var client = new TelegramBotClient("5634953591:AAEWzLkitszQUtwfbizqerd2Y5cwGPlQh2o");
            client.StartReceiving(Update, Error);
            BotClient = client;
            JsonHandler.Starter();
            Console.ReadLine();
        }

        async static Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            if (update.Type == UpdateType.Message && update.Message.Text != null)
                await CheckCommand(botClient, update);
        }

        private async static Task CheckCommand(ITelegramBotClient botClient, Update update)
        {
            string text = "";
            if (update.Message.Text.Contains("/ping"))
            {
                if (update.Message.Text == "/ping_everyone" || update.Message.Text == "/ping_everyone@Maks28925_bot")
                    PingAll.Ping(botClient, update.Message);
                
                else if (update.Message.Text.Split(" ").Length != 2)
                    text = "Error: недостаточно аргументов!";
               
                else
                    text = PingCattegory.Handler(update.Message.Text, update.Message.Chat.Id);
            }
            else if (update.Message.Text.Contains("/add_cattegory") || update.Message.Text.Contains("/add_cattegory@Maks28925_bot"))
            {
                text = AddCattegory.Handler(update.Message.Text, update.Message.Chat.Id);
            }
            
            else if (update.Message.Text.Contains("/remove_cattegory") || update.Message.Text.Contains("/remove_cattegory@Maks28925_bot"))
                text = RemoveCattegory.Remove(update.Message.Text, update.Message.Chat.Id);
            
            else if (update.Message.Text == "/help" || update.Message.Text == "/help@Maks28925_bot")
                text = Help();

            else if (update.Message.Text == "/get_cattegories" || update.Message.Text == "/get_cattegories@Maks28925_bot")
                text = GetAllCategories.GetCategories(update.Message.Chat.Id);

            if (text != "")
                await BotClient.SendTextMessageAsync(update.Message.Chat.Id, text);

        }

        private static string Help() => HelpStr;

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3) => throw new NotImplementedException();
    }
}
