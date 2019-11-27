using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace P2P.Models
{
    public class Message
    {
        public static string username = "lukasvyky"; 

        [Key]
        public int ID { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public long Timestamp { get; set; }

        public Message()
        {
            Username = username;
            Timestamp = DateTime.Now.Ticks;
        }
    }
}
