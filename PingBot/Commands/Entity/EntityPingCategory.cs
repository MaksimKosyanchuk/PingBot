using Khai518Bot.Bot.Commands;
using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PingBot.Commands.Entity
{
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
            await client.SendTextMessageAsync(upd.Message.Chat.Id, text);
        }
    }
}