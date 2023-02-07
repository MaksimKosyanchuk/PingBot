using System;

namespace PingBot
{
    public class PingCattegory
    {

        public static string Handler(string text)
        {
            string[] userCommand = text.Split();
            if (userCommand.Length == 2)
            {
                var cattegory = userCommand[1];
                if (Program.AllCattegoryes.ContainsKey(cattegory))
                    return Ping(cattegory);
                else
                    return "Error: нет такой категории";
            }
            return "error: 219b21";
        }
        public static string Ping(string cattegory)
        {
            var value = Program.AllCattegoryes[cattegory];
            var joinedNames = String.Join(", ", value.Users.ToArray());
            return $"{cattegory}, Вас пинганули: {joinedNames}";
        }
    }
}
