using System.ComponentModel;

namespace PingBot
{
    public class RemoveCategory
    {
        public static string Remove(string text, long ChatId)
        {
            var userCommand = text.Split(" ");

            if (userCommand.Length != 2) throw new MyExceptions.ErrorArgumentsCount();
            
            if (!JsonHandler.CheckCategoryInChatId(userCommand[1], ChatId))
                throw new MyExceptions.CategoryNotFound();

            var jsonObj = JsonHandler.GetJsonObj();
            jsonObj[ChatId.ToString()].Remove(userCommand[1]);
            JsonHandler.WriteFile(jsonObj);
            return $"{Strings.CategoryRemoved} {userCommand[1]}";
        }
    }
}
