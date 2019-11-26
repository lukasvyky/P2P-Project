using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P2P.Models;
using P2P.Services;

namespace P2P.Controllers
{
    [Route("/")]
    public class ClientController : Controller
    {
        private readonly MainService mainService;

        public ClientController(MainService service)
        {
            this.mainService = service;
        }

        [Route("")]
        public IActionResult Main()
        {       
            var model = new MainViewModel(mainService.GetAllMessages(), Message.username);      
            return View(model);
        }

        [HttpPost("updateUsername")]
        public IActionResult UpdateUsername(string username)
        {
            Message.username = username;
            return RedirectToAction("Main");
        }

        [HttpPost("sendMessage")]
        public IActionResult SendMessage(Message message)
        {
            mainService.SaveMessage(message);
            var toSend = new JsonMessage();
            toSend.Message = message;
            toSend.Client = new IDthing {ID = "lukasvyky"};

            mainService.ForwardMessage(toSend);

            return RedirectToAction("Main");
        }
    }
}