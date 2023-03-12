using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using Telegram.Bot.Types;

namespace PingBot
{
    internal class MyStrings
    {
        public const string GetHelpStr = "/ping [category] - to ping category\n/ping_everyone- to ping_all\n/add_category [category_name] [@people] - to added category\n/remove_category [category] - to delete category\n/get_categories - to get all categories";
        public const string NoOneCategory = "Нет ни одной категории";
        public const string ItsAllCategory = "Вот все категории:\n";
        public const string CategoryCreated = "Отлично! Создана категория";
        public const string YouveBeenPinged = "Вас пинганули:";


        public class Commands
        {
            public const string Ping = "/ping";
            public const string PingEveryone = "/ping_everyone";
            public const string AddCategory = "/add_category";
            public const string RemoveCategory = "/remove_category";
            public const string GetCategories = "/get_categories";
            public const string Help = "/help";

            public static List<string> AllCategory = new List<string>() { Ping, PingEveryone,
                                                                AddCategory, RemoveCategory, GetCategories,
                                                                Help};
            public static List<string> AllCategoryWithNick = AllCategory.Select(x => x + Program.BotLogin).ToList();
        }

        public class Errors
        {
            public static string ArgumentsCount = "Ошибка! Неверное количество аргументов!";
            public static string CategoryNotFound = "Ошибка! Категория не найдена!";
        }

        public static string CategoryRemoved = "Отлично! Категория успешно удалена!";
        
    }
}
