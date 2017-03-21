using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModel;
using TheWorld.Services;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;

        public AppController(IMailService mailService)
        {
            _mailService = mailService;
        }
        /// <summary>
        /// Action: Method that returns a view
        /// 
        /// Returns an interface
        /// Find view, render that view and return it to the user
        /// </summary>
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            _mailService.SendMail("bradon@f.com,", model.Email, "From TheWorld", model.Message);

            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
