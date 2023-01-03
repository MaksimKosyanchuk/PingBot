using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace PingBot
{
    public class CattegoryClass
    {
        public class User
        {
            public string Name;
            public int Id;
        }
        public class Cattegory
        {
            public List<string> Users;
            public long ChatId;
            public Cattegory(List<string> users, long chatId)
            {
                Users = users;
                ChatId = chatId;
            }
        }
    }
}
