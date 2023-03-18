using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Khai518Bot.Bot.Commands;
using System;

namespace PingBot.Commands.Entity
{
    [Command(@"help")]
    public class EntityHelp : Command
    {
        public override async Task Execute(Update upd, ITelegramBotClient client)
        {
            var text = Strings.GetHelpStr;
            await client.SendTextMessageAsync(upd.Message.Chat.Id, text, parseMode: ParseMode.Html);
        }
    }
}
