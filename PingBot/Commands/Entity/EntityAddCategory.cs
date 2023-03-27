using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using PingBot.Commands;
using System;

namespace PingBot.Commands.Entity;

[Command(@"add_category")]
public class EntityAddCategory : Command
{
    public override async Task Execute(Update upd, ITelegramBotClient client)
    {
        var text = "";
        try
        {
            text = await AddCategory.Handler(upd);
        }
        catch (Exception e)
        {
            text = e.Message;
        }
        Logger.Logger.Log(text, upd.Message.Chat.Id);
        await client.SendTextMessageAsync(upd.Message.Chat.Id, text, parseMode: ParseMode.Markdown);
    }
}
