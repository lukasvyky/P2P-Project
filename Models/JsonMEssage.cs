using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P2P.Models
{
    public class JsonMessage
    {
        public Message Message { get; set; }

        public Client Client { get; set; }

        public JsonMessage()
        {

        }
    }
}
