using System.Linq;
using System.Collections.Generic;

namespace PingBot
{
    internal class GetAllCategories
    {
        public static string GetCategories(long ChatId)
        {
            var jsonObj = JsonHandler.GetJsonObj();
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
