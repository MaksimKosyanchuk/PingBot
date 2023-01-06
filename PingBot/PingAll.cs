using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Linq;

namespace PingBot
{
    public class PingAll
    {
        public async static void Ping(TelegramBotClient BotClient, Message message)
        {
            var users = await BotClient.GetChatAdministratorsAsync(message.Chat);
            var toPing = users.Where(x => !x.User.IsBot).Select(x => $"[.](tg://user?id={x.User.Id})").Aggregate((x, y) => x + y);
            await BotClient.SendTextMessageAsync(message.Chat, $" {toPing}", parseMode: ParseMode.Markdown);
        }
    }
}
