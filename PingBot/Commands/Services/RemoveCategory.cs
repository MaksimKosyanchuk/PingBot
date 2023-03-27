using System.Threading.Tasks;

namespace PingBot
{
    public class RemoveCategory
    {
        public static async Task<string> Remove(string text, long ChatId)
        {
            var userCommand = text.Split(" ");

            if (userCommand.Length != 2) throw new Exceptions.ErrorArgumentsCount(ChatId);
            
            if (! await JsonHandler.CheckCategoryInChatId(userCommand[1], ChatId))
                throw new Exceptions.CategoryNotFound(ChatId);

            var jsonObj = await JsonHandler.GetJsonObjAsync();
            jsonObj[ChatId.ToString()].Remove(userCommand[1]);
            JsonHandler.WriteFile(jsonObj);
            await TelegramBotCommands.SetCommands();
            return $"{Strings.CategoryRemoved}: <b>{userCommand[1]}</b>";
        }
    }
}
