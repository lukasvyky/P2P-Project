using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2P.Models
{
    public class MainViewModel
    {
        public List<Message> Messages { get; set; }
        public string CurrentUserName { get; set; }

        public MainViewModel(List<Message> messages, string username)
        {
            Messages = messages;
            CurrentUserName = username;
        }
    }
}
