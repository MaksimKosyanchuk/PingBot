using PingBot;
using System.Collections.Generic;
using Telegram.Bot.Types;

namespace Khai518Bot.Bot.Commands;

public interface ICommandFactory
{
    IEnumerable<Command> CreateCommands(Update update);
}