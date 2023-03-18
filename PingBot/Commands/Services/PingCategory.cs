using System.Threading.Tasks;

namespace PingBot
{
    public class PingCategory
    {

        public static async Task<string> Handler(string text, long ChatId)
        {
            string[] userCommand = text.Replace("@" + Program.BotLogin, "").Split("_");
            if (userCommand.Length != 2)
                throw new Exceptions.ErrorArgumentsCount(ChatId);
            
            var category = userCommand[1];
            return await JsonHandler.CheckCategoryInChatId(category, ChatId) ? await Ping(category, ChatId) : throw new Exceptions.CategoryNotFound(ChatId);
        }

        public static async Task<string> Ping(string category, long ChatId) => $"{category}, {Strings.YouveBeenPinged} {await JsonHandler.GetUsersNameFromCategory(category, ChatId)}";
    }
}
