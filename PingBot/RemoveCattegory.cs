using System.Globalization;
using System.Linq;
using Telegram.Bot.Types;

namespace PingBot
{
    public class RemoveCattegory
    {
        public static string Remove(Update update)
        {
            string[] userCommand = update.Message.Text.Split(" ");
            if (userCommand.Length != 2)
            {
                return "Error: неправильное количество аргументов!";
            }
            int i = 1;
            string[] cattegoryes = Program.AllCattegoryes.Keys.ToArray();
            foreach (var cattegory in Program.AllCattegoryes)
            {
                if (userCommand[1] == cattegory.Key)
                {
                    Program.AllCattegoryes.Remove(cattegory.Key);
                    string text = $"Removed {cattegory.Key}";
                    return text;
                }
            }
            return "error ";
        }
    }
}
