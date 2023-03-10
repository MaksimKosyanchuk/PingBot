using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PingBot
{
    internal class JsonHandler
    {
        public static Dictionary<string, Dictionary<string, string[]>> GetJsonObj()
        {
            string str = GetStrFromJson();
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

        public static bool CheckCattegoryInChatId(string text, long ChatId)
        {
            var jsonFile = GetJsonObj();
            return jsonFile.Where(p => p.Key == ChatId.ToString()).Any(p => p.Value.Keys.Contains(text));
        }

        private static string GetStrFromJson()
        {
            using (var file = new StreamReader("file.json"))
                return file.ReadToEnd();
        }

        public static string GetUsersNameFromCattegory(string cattegory, long ChatId)
        {
            var jsonFile = GetJsonObj();
            return jsonFile
                .Where(p => p.Key == ChatId.ToString())
                .SelectMany(p => p.Value)
                .Where(p => p.Key == cattegory)
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
    }
}
