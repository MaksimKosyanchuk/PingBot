using System.Collections.Generic;
using System.Linq;

namespace PingBot
{
    public class AddCattegory
    {
        public static string Handler(string text, long ChatId)
        {
            string[] userCommand = text.Split(" ");
            if (!CheckCorrectCommand(userCommand)) return "Error: неправильное количество аргументов!";
            string[] usersList = userCommand.Skip(2).ToArray();

            AppendNewCattegory(usersList, userCommand[1], ChatId);
            return $"Отлично! Создана категория {userCommand[1]}";
        }

        private static void AppendNewCattegory(string[] userList, string cattegory, long ChatId)
        {
            var jsonFile = JsonHandler.GetJsonObj();
            try
            {
                jsonFile[ChatId.ToString()].Add(cattegory, userList);
            }
            catch
            {
                jsonFile.Add(ChatId.ToString(), new Dictionary<string, string[]>() {{cattegory, userList }});
            }
            JsonHandler.WriteFile(jsonFile);
        }

        private static bool CheckCorrectCommand(string[] userCommand) => (userCommand.Length <= 2 || userCommand[1].Contains("@")) ? false : userCommand.Skip(2).Any(p => p.Contains("@"));
    }
}
