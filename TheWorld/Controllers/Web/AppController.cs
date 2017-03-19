﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
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
            throw new InvalidOperationException("Bad things");
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
