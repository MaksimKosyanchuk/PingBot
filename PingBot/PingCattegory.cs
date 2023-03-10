namespace PingBot
{
    public class PingCattegory
    {

        public static string Handler(string text, long ChatId)
        {
            string[] userCommand = text.Split();
            if (userCommand.Length == 2)
            {
                var cattegory = userCommand[1];
                return JsonHandler.CheckCattegoryInChatId(cattegory, ChatId) ? Ping(cattegory, ChatId) : "Ошибка! Нет такой категории";
            }
            return "Ошибка! Неправильное количество аргументов!";
        }
        public static string Ping(string cattegory, long ChatId) => $"{cattegory}, Вас пинганули: {JsonHandler.GetUsersNameFromCattegory(cattegory, ChatId)}";
    }
}
