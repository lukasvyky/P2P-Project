using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using P2P.Models;
using P2P.Services;

namespace P2P.Controllers
{
    [Route("api")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly MainService mainService;

        public ApiController(MainService service)
        {
            this.mainService = service;
        }

        [HttpPost("message/receive")]
        public IActionResult SaveIncomingMessage([FromBody]JsonMessage message)
        {
            if (message.Client.ID.Equals(Environment.GetEnvironmentVariable("UNIQUE_ID")))
                return StatusCode(200);

            if (message.Message == null || message.Client == null)
                return StatusCode(401, new { status = "error", message = "Check your code bro" });

            var properMessage = new Message
            {
                Text = message.Message.Text,
                Timestamp = message.Message.Timestamp,
                Username = message.Message.Username
            };

            mainService.SaveMessage(properMessage);
            mainService.ForwardMessage(message);

            return StatusCode(200, new { status = "ok" });
        }
    }
}
