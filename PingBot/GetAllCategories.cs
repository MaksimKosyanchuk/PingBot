using System.Linq;
using Telegram.Bot.Types;

namespace PingBot
{
    internal class GetAllCategories
    {
        public static string GetCategories(Update update)
        {
            string[] cattegories = Program.AllCattegoryes.Keys.ToArray();
            return (cattegories.Length == 0) ? "Ни одной категории нет" : "Вот все категории:\n" + Program.AllCattegoryes.Where(p => p.Value.ChatId == update.Message.Chat.Id).Select((x, i) => $"{i + 1}: {cattegories[i]}\n").Aggregate((current, next) => current + next);
        }
    }
}
