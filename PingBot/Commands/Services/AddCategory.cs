using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace PingBot
{
    public class AddCategory
    { 
        public static async Task<string> Handler(Update upd)
        {
            string[] userCommand = upd.Message.Text.Split(" ");
            if (!CheckCorrectCommand(userCommand)) throw new Exceptions.ErrorArgumentsCount(upd.Message.Chat.Id);
            string[] usersList = userCommand.Skip(2).ToArray();

            await AppendNewCategory(usersList, userCommand[1], upd.Message.Chat.Id);

            return $"{Strings.CategoryCreated} {userCommand[1]}";
        }

        private static async Task AppendNewCategory(string[] userList, string category, long ChatId)
        {
            var jsonFile = await JsonHandler.GetJsonObjAsync();
            try
            {
                jsonFile[ChatId.ToString()].Add(category, userList);
            }
            catch
            {
                jsonFile.Add(ChatId.ToString(), new Dictionary<string, string[]>() {{category, userList }});
            }
            JsonHandler.WriteFile(jsonFile);
            Strings.Commands.AllCategory.Add("/ping_" + category);
            await TelegramBotCommands.SetCommands();
        }

        private static bool CheckCorrectCommand(string[] userCommand) => (userCommand.Length <= 2 || userCommand[1].Contains("@")) ? false : userCommand.Skip(2).Any(p => p.Contains("@"));
    }
}
