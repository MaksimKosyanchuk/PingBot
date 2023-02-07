using System.Linq;
using Telegram.Bot.Types;

namespace PingBot
{
    internal class GetAllCategories
    {
        public static string GetCategories(Update update)
        {
            string text = "Вот все категории:\n";
            string[] cattegories = Program.AllCattegoryes.Keys.ToArray();
            if (cattegories.Length == 0) return "Ни одной категории нет!";
            return text + Program.AllCattegoryes.Where(p => p.Value.ChatId == update.Message.Chat.Id).Select((x, i) => $"{i + 1}: {cattegories[i]}\n").Aggregate((current, next) => current + next);
        }
    }
}
