using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PingBot.Commands.Entity;

[Command(@"remove_category")]
public class EntityRemoveCategory : Command
{
    public override async Task Execute(Update upd, ITelegramBotClient client)
    {
        string text = "";
        try
        {
            text = await RemoveCategory.Remove(upd.Message.Text, upd.Message.Chat.Id);
        }
        catch (Exception e)
        {
            text = e.Message;
        }
        await client.SendTextMessageAsync(upd.Message.Chat.Id, text, parseMode: ParseMode.Html);
        Logger.Logger.Log(text, upd.Message.Chat.Id);
    }
}
