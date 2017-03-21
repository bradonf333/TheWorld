﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheWorld.ViewModel;
using TheWorld.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;

        public AppController(IMailService mailService, IConfigurationRoot config)
        {
            _mailService = mailService;
            _config = config;
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
            // Example of an error we can generate - this will show up on the email field
            if (model.Email.Contains("aol.com")) ModelState.AddModelError("Email", "We don't support AOL addresses");

            // Blank string in the beginning will put the error in the summary section, not specifically on the email field
            if (model.Email.Contains("aol.com")) ModelState.AddModelError("", "We don't support AOL addresses");

            // Makes sure the data is correct on the server side
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From TheWorld", model.Message);

                ViewBag.UserMessage = "Message Sent";
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
