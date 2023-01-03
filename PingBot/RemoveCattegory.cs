using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PingBot
{
    public class RemoveCattegory
    {
        public static void Remove()
        {
            string[] userCommand = Program.NewUpdate.Message.Text.Split(" ");
            if (userCommand.Length != 2)
            {
                Program.PushText("Error: неправильное количество аргументов!");
                return;
            }
            int i = 1;
            string[] cattegoryes = Program.AllCattegoryes.Keys.ToArray();
            foreach (var cattegory in Program.AllCattegoryes)
            {
                if (userCommand[1] == cattegory.Key)
                {
                    Program.AllCattegoryes.Remove(cattegory.Key);
                    Program.PushText($"Removed {cattegory.Key}");
                    return;
                }
            }
            Program.PushText("Error: Нет такой категории");
        }
    }
}
