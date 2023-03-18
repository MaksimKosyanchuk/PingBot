using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace PingBot;

public abstract class Command
{
    public abstract Task Execute(Update upd, ITelegramBotClient client);
    protected ITelegramBotClient BotClient { get; set; } = null!;
    protected Update Update { get; set; } = null!;
    protected Message Message => Update.Message ?? Update.CallbackQuery!.Message!;

    public void Init(ITelegramBotClient botClient, Update update)
    {
        BotClient = botClient;
        Update = update;
    }
}