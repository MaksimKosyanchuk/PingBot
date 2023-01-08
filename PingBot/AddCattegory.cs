using System;
using System.Collections.Generic;
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
            {
                List<string> usersList = new List<string>();
                for (int i = 0; i < userCommand.Length; i++)
                {
                    if (i == 0 || i == 1)
                        continue;
                    usersList.Add(userCommand[i]);
                }
                var cattegory = new CattegoryClass.Cattegory(usersList, update.Message.Chat.Id);
                Console.WriteLine();
                Program.AllCattegoryes.Add(userCommand[1], cattegory);
                return $"Отлично! Создана категория {userCommand[1]}";
            }
            return "Error: неправильное количесво аргументов!";
        }

        private static bool CheckCorrectCommand(string[] userCommand, int countMemebers)
        {
            if (userCommand.Length-2 > countMemebers)
            {
                return false;
            }
            else if (userCommand.Length <= 2)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < userCommand.Length; i++)
                {
                    if (i == 0 || i == 1)
                        continue;
                    if (!userCommand[i].Contains("@"))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
