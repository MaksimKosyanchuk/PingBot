using System.Collections.Generic;
using Telegram.Bot.Types;

namespace PingBot.Commands;

public interface ICommandFactory
{
    IEnumerable<Command> CreateCommands(Update update);
}