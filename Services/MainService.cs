using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using P2P.Database;
using P2P.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P2P.Services
{
    public class MainService
    {
        private readonly P2PContext AppContext;

        public MainService(P2PContext AppContext)
        {
            this.AppContext = AppContext;
        }


        public List<Message> GetAllMessages() 
        {
            using (var currentContext = AppContext) 
            {
                return currentContext.Messages.ToList();    
            } 
        }

        public void SaveMessage(Message message) 
        {
            using (var currentContext = AppContext)
            {
                currentContext.Messages.Add(message);
                currentContext.SaveChanges();
            }
        }

        public async Task ForwardMessage(JsonMessage message)
        {
            var client = new HttpClient();
            var stringContent = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://192.168.1.173:5001/api/message/receive", stringContent);

            if (!response.IsSuccessStatusCode)
            {
                Console.Error.WriteLine(response.StatusCode);
            }
            else
            {
                Console.WriteLine("Sent");
            }
        }
    }
}
