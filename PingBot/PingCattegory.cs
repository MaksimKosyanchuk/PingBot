using System;

namespace PingBot
{
    public class PingCattegory
    {

        public static void Handler(string text)
        {
            string[] userCommand = text.Split();
            if (userCommand.Length == 2)
            {
                var cattegory = userCommand[1];
                if (Program.AllCattegoryes.ContainsKey(cattegory))
                {
                    Ping(cattegory);
                }
                else
                {
                    Program.PushText("Error: нет такой категории");
                    return;
                }
            }
        }
        public static void Ping(string cattegory)
        {
            var value = Program.AllCattegoryes[cattegory];
            var joinedNames = String.Join(", ", value.Users.ToArray());
            string text = $"{cattegory}, Вас пинганули: {joinedNames}";
            Program.PushText(text);
        }
    }
}
