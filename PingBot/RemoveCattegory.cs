using System.ComponentModel;

namespace PingBot
{
    public class RemoveCattegory
    {
        public static string Remove(string text, long ChatId)
        {
            var userCommand = text.Split(" ");

            if (userCommand.Length != 2) throw new MyExceptions.ErrorArgumentsCount();
            
            if (!JsonHandler.CheckCattegoryInChatId(userCommand[1], ChatId))
                throw new MyExceptions.CattegoryNotFound();

            var jsonObj = JsonHandler.GetJsonObj();
            jsonObj[ChatId.ToString()].Remove(userCommand[1]);
            JsonHandler.WriteFile(jsonObj);
            return $"{MyStrings.CattegoryRemoved} {userCommand[1]}";
        }
    }
}
