using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using PingBot.Commands;

namespace PingBot.Commands.Entity;

[Command(@"help")]
public class EntityHelp : Command
{
    public override async Task Execute(Update upd, ITelegramBotClient client)
    {
        string text = await Strings.GetHelpStr(client);
        await client.SendTextMessageAsync(upd.Message.Chat.Id, text, parseMode: ParseMode.Html);
    }
}
