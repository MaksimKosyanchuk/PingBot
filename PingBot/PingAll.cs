using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using System.Threading;
using System.Linq;

namespace PingBot
{
    public class PingAll
    {
        public async static void Ping(TelegramBotClient BotClient, Message message)
        {
            var users = await BotClient.GetChatAdministratorsAsync(message.Chat);
            var toPing = users.Where(x => !x.User.IsBot).Select(x => $"[.](tg://user?id={x.User.Id})").Aggregate((x, y) => x + y);
            await BotClient.SendTextMessageAsync(message.Chat, $"Вебхуков до сих пор нет {toPing}", parseMode: ParseMode.Markdown);
        }
    }
}
