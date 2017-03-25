using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Models;

namespace TheWorld.Controllers.Api
{
    public class TripsController : Controller
    {
        /* 
         * ===============================================================
         *      -- Return the Api as JSON
         *      
         *  This is how we set it up beforehand, but switched to below.
         *  -Wanted to keep this as an example.
         *  
         *  Using JSON we can't really return any errors.
         * ===============================================================
         */
        /*
       // When this url is called it will then call this method
       /// <summary>
       /// Serializes as Json file
       /// </summary>
       /// <returns>Json</returns>
       [HttpGet("api/trips")]
       public JsonResult Get()
       {
           return Json(new Trip() {Name = "My Trip" });
       }
       */

        /* 
         * ================================================================
         *  IActionResult we can return a response code. Ok is for success
         * 
         * -Using this still returns JSON in the Api.
         *  -If an error happens we can handle that here.
         * ================================================================
         */
        // When this url is called it will then call this method
        /// <summary>
        /// Serializes as Json file
        /// </summary>
        /// <returns>Json</returns>
        [HttpGet("api/trips")]
        public IActionResult Get()
        {
            return Ok(new Trip() { Name = "My Trip" });
        }
    }
}
