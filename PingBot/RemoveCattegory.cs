namespace PingBot
{
    public class RemoveCattegory
    {
        public static string Remove(string text, long ChatId)
        {
            string[] userCommand = text.Split(" ");

            if (userCommand.Length != 2) return "Ошибка!: неправильное количество аргументов!";
            
            if (JsonHandler.CheckCattegoryInChatId(userCommand[1], ChatId))
            {
                var jsonObj = JsonHandler.GetJsonObj();
                jsonObj[ChatId.ToString()].Remove(userCommand[1]);
                JsonHandler.WriteFile(jsonObj);
                return $"Отлично! Удалена категория {userCommand[1]}";
            }
            else return "Ошибка! Категория не найдена!";
        }
    }
}
