/*using Khai518Bot.Bot.Commands;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PingBot.Commands.Entity
{
    [Command(@"ping_everyone")]
    public class EntityPingEveryOne : Command
    {
        public override async Task Execute(Update upd, ITelegramBotClient client)
        {
            var text = await PingAll.Ping(client, upd.Message);
            await client.SendTextMessageAsync(upd.Message.Chat.Id, text, parseMode: ParseMode.Markdown);
        }
    }
}*/