namespace PingBot
{
    public class PingCattegory
    {

        public static string Handler(string text, long ChatId)
        {
            string[] userCommand = text.Split();
            if (userCommand.Length != 2)
                throw new MyExceptions.ErrorArgumentsCount();
            
            var cattegory = userCommand[1];
            return JsonHandler.CheckCattegoryInChatId(cattegory, ChatId) ? Ping(cattegory, ChatId) : throw new MyExceptions.CattegoryNotFound();
        }
        public static string Ping(string cattegory, long ChatId) => $"{cattegory}, {MyStrings.YouveBeenPinged} {JsonHandler.GetUsersNameFromCattegory(cattegory, ChatId)}";
    }
}
