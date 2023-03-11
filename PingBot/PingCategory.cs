namespace PingBot
{
    public class PingCategory
    {

        public static string Handler(string text, long ChatId)
        {
            string[] userCommand = text.Split();
            if (userCommand.Length != 2)
                throw new MyExceptions.ErrorArgumentsCount();
            
            var category = userCommand[1];
            return JsonHandler.CheckCategoryInChatId(category, ChatId) ? Ping(category, ChatId) : throw new MyExceptions.CategoryNotFound();
        }
        public static string Ping(string category, long ChatId) => $"{category}, {MyStrings.YouveBeenPinged} {JsonHandler.GetUsersNameFromCategory(category, ChatId)}";
    }
}
