
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
                
                if (Program.AllCattegoryes.ContainsKey(cattegory)) return Ping(cattegory);

                else return "Error: нет такой категории";
            }
            return "error: Incorrect count of arguments";
        }
        public static string Ping(string cattegory)
        {
            var value = Program.AllCattegoryes[cattegory];
            var joinedNames = string.Join(", ", value.Users.ToArray());
            return $"{cattegory}, Вас пинганули: {joinedNames}";
        }
    }
}
