using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PingBot
{
    internal class GetAllCategories
    {
        public static async Task<string> GetCategories(long ChatId)
        {
            Dictionary<string, Dictionary<string, string[]>> jsonObj = await JsonHandler.GetJsonObj();
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
