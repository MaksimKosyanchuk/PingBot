using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Telegram.Bot.Types;

namespace PingBot
{
    internal class MyStrings
    {
        public const string GetHelpStr = $"{Commands.Ping} [category] - to ping category\n" +
        $"{Commands.PingEveryone} - to ping_all\n" +
        $"{Commands.AddCategory} [category_name] [@people] - to added category\n" +
        $"{Commands.RemoveCategory} [category] - to delete category\n" +
        $"{Commands.GetCategories} - to get all categories";

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
                                                                AddCategory, RemoveCategory, 
                                                                GetCategories, Help};
        }

        public class Errors
        {
            public static string ArgumentsCount = "Ошибка! Неверное количество аргументов!";
            public static string CategoryNotFound = "Ошибка! Категория не найдена!";
        }

        public static string CategoryRemoved = "Отлично! Категория успешно удалена!";
        
    }
}
