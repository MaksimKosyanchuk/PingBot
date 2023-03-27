using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PingBot.Commands.Entity;

[Command(@"ping")]
public class EntityPingCategory : Command
{
    public override async Task Execute(Update upd, ITelegramBotClient client)
    {
        var text = "";
        try
        {
            text = await PingCategory.Handler(upd.Message.Text, upd.Message.Chat.Id);
        }
        catch (Exception e)
        {
            text = e.Message;
        }
        Console.WriteLine(text);
        await client.SendTextMessageAsync(upd.Message.Chat.Id, text, parseMode: ParseMode.Html);
    }
}
