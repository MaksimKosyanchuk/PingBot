using System.Linq;
using Telegram.Bot.Types;

namespace PingBot
{
    public class RemoveCattegory
    {
        public static string Remove(Update update)
        {
            string[] userCommand = update.Message.Text.Split(" ");

            if (userCommand.Length != 2) return "Error: неправильное количество аргументов!";
            
            var cattegory = Program.AllCattegoryes.FirstOrDefault(p => userCommand[1] == p.Key);

            if (cattegory.Key != null)
            {
                Program.AllCattegoryes.Remove(cattegory.Key);
                return $"Removed {cattegory.Key}";
            }

            else return "error, cattegory not found";
        }
    }
}
