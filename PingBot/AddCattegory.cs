using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using static PingBot.CattegoryClass;

namespace PingBot
{
    public class AddCattegory
    {
        public async static void Handler(string text)
        {
            string[] userCommand = text.Split(" ");

            var countMembers = await Program.BotClient.GetChatMemberCountAsync(Program.NewUpdate.Message.Chat.Id);
            if (CheckCorrectCommand(userCommand, countMembers))
            {
                List<string> usersList = new List<string>();
                for (int i = 0; i < userCommand.Length; i++)
                {
                    if (i == 0 || i == 1)
                        continue;
                    usersList.Add(userCommand[i]);
                }
                var cattegory = new CattegoryClass.Cattegory(usersList, Program.NewUpdate.Message.Chat.Id);
                Console.WriteLine();
                Program.AllCattegoryes.Add(userCommand[1], cattegory);
                Program.PushText($"Отлично! Создана категория {userCommand[1]}");
            }
        }

        private static bool CheckCorrectCommand(string[] userCommand, int countMemebers)
        {
            if (userCommand.Length-2 > countMemebers)
            {
                Program.PushText("Error: Число пользователей категории не может превышать число пользователей группы!");
                return false;
            }
            else if (userCommand.Length <= 2)
            {
                Program.PushText("Error: недостаточно аргументов!");
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
                        Program.PushText("Error: все пользователи должны быть отмечены через '@'!");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
