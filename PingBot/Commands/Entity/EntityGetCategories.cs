using PingBot.Commands;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PingBot.Commands.Entity;

[Command(@"get_categories")]
public class EntityGetCategories : Command
{
    public override async Task Execute(Update upd, ITelegramBotClient client)
    {
        var text = await GetAllCategories.GetCategories(upd, upd.Message.Chat.Id);
        await client.SendTextMessageAsync(upd.Message.Chat.Id, text, parseMode: ParseMode.Html);
    }
}
