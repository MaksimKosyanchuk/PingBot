using System.Collections.Generic;
using System.Linq;
using System;
using System.Reflection;
using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace PingBot.Commands;

public class CommandFactory : ICommandFactory
{
    private readonly ITelegramBotClient _botClient;

    public readonly Dictionary<CommandAttribute, Type> _commands = new();

    public CommandFactory(ITelegramBotClient botClient)
    {
        _botClient = botClient;
        InitializeCommands();
    }

    private void InitializeCommands()
    {
        var commandTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsSubclassOf(typeof(Command)) && !t.IsAbstract);

        foreach (var type in commandTypes)
        {
            var attribute = type.GetCustomAttribute<CommandAttribute>();
            if (attribute == null)
            {
                continue;
            }
            _commands.Add(attribute, type);
        }
    }

    private static bool ShouldBeInvoked(CommandAttribute attribute, Update update)
    {
        if (attribute.UpdateType != update.Type)
            return false;
        if (attribute.UpdateType != UpdateType.Message && attribute.UpdateType != UpdateType.CallbackQuery)
            return true;
        if (!attribute.HasCommand)
            return true;
        if (!string.IsNullOrEmpty(update.Message?.Text))
        {
            if (update.Message.Text.Replace("@" + Program.BotLogin, "").Split(" ")[0] == "/" + attribute.Command)
            {
                return true;
            }
            else
            {
                var jsonObj = JsonHandler.GetJsonObj();
                bool finded = false;
                foreach (var category in jsonObj.Values)
                {
                    finded = category.Keys.Any(_category => update.Message.Text.Replace("@" + Program.BotLogin, "").Split(" ")[0] == "/" + attribute.Command + $"_{_category}");
                }
                return finded;
            }
        }
        return !string.IsNullOrEmpty(update.CallbackQuery?.Data) &&
               update.CallbackQuery.Data.StartsWith($"{attribute.Command}");
    }

    public IEnumerable<Command> CreateCommands(Update update)
    {
        foreach (var (_, type) in _commands.Where(x => ShouldBeInvoked(x.Key, update)))
        {
            var instance = Activator.CreateInstance(type);
            if (instance is not Command command) continue;
            command.Init(_botClient, update);
            yield return command;
        }
    }
}