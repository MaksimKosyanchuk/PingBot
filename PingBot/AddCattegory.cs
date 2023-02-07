using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types;
using System;

namespace PingBot
{
    public class AddCattegory
    {
        public static string Handler(string text, Update update)
        {
            string[] userCommand = text.Split(" ");
            if (!CheckCorrectCommand(userCommand)) return "Error: неправильное количество аргументов!";
            
            List<string> usersList = userCommand.Skip(2).ToList();
            var cattegory = new CattegoryClass.Cattegory(usersList, update.Message.Chat.Id);
            Program.AllCattegoryes.Add(userCommand[1], cattegory);
            return $"Отлично! Создана категория {userCommand[1]}";
        }

        private static bool CheckCorrectCommand(string[] userCommand) => (userCommand.Length <= 2) ? false : userCommand.Skip(2).Any(p => p.Contains("@"));
    }
}
