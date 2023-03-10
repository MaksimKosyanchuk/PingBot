namespace PingBot
{
    internal class MyStrings
    {
        public const string GetHelpStr = "/ping [cattegory] - to ping cattegory\n/ping_everyone- to ping_all\n/add_cattegory [cattegory_name] [@people] - to added cattegory\n/remove_cattegory [cattegory] - to delete cattegory\n/get_cattegories - to get all cattegories";
        public const string NoOneCattegory = "Нет ни одной категории";
        public const string ItsAllCattegory = "Вот все категории:\n";
        public const string CattegoryCreated = "Отлично! Создана категория";
        public const string YouveBeenPinged = "Вас пинганули:";
        public class Errors
        {
            public static string ArgumentsCount = "Ошибка! Неверное количество аргументов!";
            public static string CattegoryNotFound = "Ошибка! Категория не найдена!";
        }

        public static string CattegoryRemoved = "Отлично! Категория успешно удалена!";
        
    }
}
