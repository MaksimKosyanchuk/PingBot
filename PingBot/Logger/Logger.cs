using System;
using System.IO;

namespace PingBot.Logger
{
    public class Logger
    {
        public static void Log(string text, long ChatId)
        {
            using (var reader = new StreamWriter("Log/log.txt", true))
            {
                var dateTime = DateTime.Now;
                reader.WriteLine($"| {dateTime.ToString()} | {ChatId} | " + text);
            }
            AlignText();
        }

        private static void AlignText()
        {
            string text;
            string[] lines;
            using (var reader = new StreamReader("Log/log.txt"))
            {
                lines = reader.ReadToEnd().Split("\n");
            }
            int maxSize = 0;
            foreach (var str in lines)
            {
                if (str.Split("|").Length == 4 && str.Split("|")[2].Replace(" ", "").Length > maxSize)
                {
                    maxSize = str.Split("|")[2].Replace(" ", "").Length;
                }
            }
            text = "";
            foreach (var column in lines)
            {
                if (column.Split("|").Length == 4)
                {
                    text += "|" + column.Split("|")[1];
                    text += "| ";
                    var str = column.Split("|")[2].Replace(" ", "");
                    if (str.Length < maxSize)
                    {
                        for (int i = 0; i < (maxSize - str.Length + 4); i++)
                            str += " ";
                    }
                    text += str;
                    text += " |" + column.Split("|")[3] + "\n";
                }
            }
            using (var writer = new StreamWriter("Log/log.txt", false))
            {
                writer.Write(text);
            }
        }

        public static void Starter()
        {
            if (!File.Exists("Log/log.txt"))
            {
                string folderName = "Log";
                string fileName = "log.txt";
                string pathString = Path.Combine(Environment.CurrentDirectory, folderName);
                Directory.CreateDirectory(pathString);
                string filePath = Path.Combine(pathString, fileName);
                File.Create(filePath).Close();
            }
        }
    }
}
