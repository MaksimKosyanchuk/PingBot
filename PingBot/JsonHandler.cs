using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PingBot
{
    internal class JsonHandler
    {
        public static async Task<Dictionary<string, Dictionary<string, string[]>>> GetJsonObj()
        {
            string str = await GetStrFromJson();
            return JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, string[]>>>(str);
        }

        public static void WriteFile(Dictionary<string, Dictionary<string, string[]>> dict)
        {
            using (var file = new StreamWriter("file.json"))
            {
                string str = JsonSerializer.Serialize(dict);
                file.Write(str);
            }
        }

        public static async Task<bool> CheckCategoryInChatId(string text, long ChatId)
        {
            var jsonFile = await GetJsonObj();
            return jsonFile.Where(p => p.Key == ChatId.ToString()).Any(p => p.Value.Keys.Contains(text));
        }

        private static async Task<string> GetStrFromJson()
        {
            using (var file = new StreamReader("file.json"))
                return await file.ReadToEndAsync();
        }

        public static async Task<string> GetUsersNameFromCategory(string category, long ChatId)
        {
            var jsonFile = await GetJsonObj();
            return jsonFile
                .Where(p => p.Key == ChatId.ToString())
                .SelectMany(p => p.Value)
                .Where(p => p.Key == category)
                .Select(p => p.Value)
                .FirstOrDefault()
                .Aggregate((current, next) => $"{current}, {next}");
        }
        public static void Starter()
        {
            try
            {
                var file = GetAllCategories.GetCategories(1);
            }
            catch
            {
                CreateFile();
            }
        }

        private static void CreateFile()
        {
            using (var file = new StreamWriter("file.json"))
            {
                file.Write("{}");
            }
        }

        public static string GetBotToken()
        {
            using (var file = new StreamReader("botconfig.json"))
            {
                return JsonSerializer.Deserialize<Dictionary<string, string>>(file.ReadToEnd())["token"];
            }
        }
    }
}
