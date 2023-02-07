using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PingBot
{
    public class AddCattegory
    {
        public static string Handler(string text, Update update, int countMembers)
        {
            string[] userCommand = text.Split(" ");

            if (CheckCorrectCommand(userCommand, countMembers))
                return "Error: неправильное количество аргументов!";
            
            List<string> usersList = userCommand.Skip(2).ToList();
            var cattegory = new CattegoryClass.Cattegory(usersList, update.Message.Chat.Id);
            Program.AllCattegoryes.Add(userCommand[1], cattegory);
            return $"Отлично! Создана категория {userCommand[1]}";
        }

        private static bool CheckCorrectCommand(string[] userCommand, int countMemebers)
        {
            if (userCommand.Length-2 > countMemebers)
                return false;
            else if (userCommand.Length <= 2)
                return false;
            else
                return userCommand.Skip(2).Any(p => !p.Contains("@"));
        }
    }
}
