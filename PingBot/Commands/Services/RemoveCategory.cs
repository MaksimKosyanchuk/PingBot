using System.Threading.Tasks;

namespace PingBot
{
    public class RemoveCategory
    {
        public static async Task<string> Remove(string text, long ChatId)
        {
            var userCommand = text.Split(" ");

            if (userCommand.Length != 2) throw new Exceptions.ErrorArgumentsCount();
            
            if (! await JsonHandler.CheckCategoryInChatId(userCommand[1], ChatId))
                throw new Exceptions.CategoryNotFound();

            var jsonObj = await JsonHandler.GetJsonObj();
            jsonObj[ChatId.ToString()].Remove(userCommand[1]);
            JsonHandler.WriteFile(jsonObj);
            await SetBotCommands.SetCommands();
            return $"{Strings.CategoryRemoved} {userCommand[1]}";
        }
    }
}
