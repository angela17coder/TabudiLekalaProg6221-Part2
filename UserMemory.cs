//Initialize TopicsDiscussed list in UserMemory
using System.Collections.Generic;

namespace CybersecurityChatbot
{
    public class UserMemory
    {
        public string UserName { get; set; }

        public string FavouriteTopic { get; set; }

        public List<string> TopicsDiscussed { get; set; } = new List<string>();
    }
}
