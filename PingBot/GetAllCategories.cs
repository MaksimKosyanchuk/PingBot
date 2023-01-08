using System.Linq;
using Telegram.Bot.Types;

namespace PingBot
{
    internal class GetAllCategories
    {
        public static string GetCategories(Update update)
        {
            string text = "Вот все категории:\n";
            string[] cattegoryes = Program.AllCattegoryes.Keys.ToArray();
            if (cattegoryes.Length == 0)
            {
                return "Ни одной категории нет!";
            }
            int i = 0;
            foreach (var cattegory in Program.AllCattegoryes)
            {
                if (cattegory.Value.ChatId == update.Message.Chat.Id)
                {
                    text += (i + 1).ToString() + ": " + cattegoryes[i] + "\n";
                    i++;
                }
            }
            return text;
        }
    }
}
