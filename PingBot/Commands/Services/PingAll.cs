using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Linq;
using System.Threading.Tasks;

namespace PingBot
{
    public class PingAll
    {
        public static async Task<string> Ping(ITelegramBotClient BotClient, Message message)
        {
            if (message.Chat.Type != ChatType.Private)
            {
                var users = await BotClient.GetChatAdministratorsAsync(message.Chat);
                var toPing = users.Where(x => !x.User.IsBot).Select(x => $"[.](tg://user?id={x.User.Id})").Aggregate((x, y) => x + y);
                return $" {toPing}";
            }
            return Strings.Errors.ItsPrivateChat;
        }
    }
}
