using System.Collections.Generic;

namespace PingBot
{
    public class CattegoryClass
    {
        public class User
        {
            public string Name { get; set; }
            public int Id { get; set; }
        }
        public class Cattegory
        {
            public List<string> Users { get; set; }
            public long ChatId { get; set; }
            public Cattegory(List<string> users, long chatId) => (Users, ChatId) = (users, chatId);
        }
    }
}
