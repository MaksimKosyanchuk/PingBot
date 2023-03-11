using System.Collections.Generic;
using System.Linq;

namespace PingBot
{
    public class AddCategory
    {
        public static string Handler(string text, long ChatId)
        {
            string[] userCommand = text.Split(" ");
            if (!CheckCorrectCommand(userCommand)) throw new MyExceptions.ErrorArgumentsCount();
            string[] usersList = userCommand.Skip(2).ToArray();

            AppendNewCategory(usersList, userCommand[1], ChatId);
            return $"{MyStrings.CategoryCreated} {userCommand[1]}";
        }

        private static void AppendNewCategory(string[] userList, string category, long ChatId)
        {
            var jsonFile = JsonHandler.GetJsonObj();
            try
            {
                jsonFile[ChatId.ToString()].Add(category, userList);
            }
            catch
            {
                jsonFile.Add(ChatId.ToString(), new Dictionary<string, string[]>() {{category, userList }});
            }
            JsonHandler.WriteFile(jsonFile);
        }

        private static bool CheckCorrectCommand(string[] userCommand) => (userCommand.Length <= 2 || userCommand[1].Contains("@")) ? false : userCommand.Skip(2).Any(p => p.Contains("@"));
    }
}
