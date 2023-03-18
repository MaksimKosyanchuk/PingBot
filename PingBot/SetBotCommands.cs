using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace PingBot
{
    public class SetBotCommands
    {
        public static async Task SetCommands()
        {
            var jsonObj = await JsonHandler.GetJsonObj();
            var commands = Strings.Commands.DefaultCommands;
            foreach (var a in jsonObj)
            {
                foreach (var b in a.Value)
                {
                    Strings.Commands.AllCategory.Add("/ping_" + b.Key);
                    var description = $"To ping" + b.Value.Aggregate((current, next) => current + next).Replace("@", ", ");
                    var newCommand = new BotCommand { Command = "ping_" + b.Key, Description = description};
                    Array.Resize(ref commands, commands.Length + 1);
                    commands[commands.Length - 1] = newCommand;
                }
            }
            await Program.Client.SetMyCommandsAsync(commands);
        }
    }   
}
