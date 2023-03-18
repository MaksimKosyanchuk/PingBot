using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Telegram.Bot.Types;
using Khai518Bot.Bot.Commands;
using Telegram.Bot.Types.Enums;

namespace PingBot
{
    internal class GetAllCategories
    {
        public static async Task<string> GetCategories(Update upd, long ChatId)
        {
            Dictionary<string, Dictionary<string, string[]>> jsonObj = await JsonHandler.GetJsonObjAsync();
            try
            {
                return (jsonObj[ChatId.ToString()].Count == 0) ? Strings.NoOneCategory :
                        Strings.ItsAllCategory + jsonObj.GetValueOrDefault(ChatId.ToString())
                        .Keys.ToList().Aggregate((current, next) => $"{current}\n{next}");
            }
            catch
            {
                return Strings.NoOneCategory;
            }
        }
    }
}
