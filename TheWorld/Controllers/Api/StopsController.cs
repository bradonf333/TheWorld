using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Models;

namespace TheWorld.Controllers.Api
{
    public class StopsController : Controller
    {
        private ILogger<StopsController> _logger;
        private IWorldRepository _repository;

        /// <summary>
        /// Constructor to initialize local variables needed
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="logger"></param>
        public StopsController(IWorldRepository repository, ILogger<StopsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        /*
         * ==============================================
         *   -- Return the stops for a specific trip --
         * ==============================================
         */
        public IActionResult Get()
        {
            // Since we are dealing with a Stop we need the trip name
            var trip = _repository.GetTripByName(string tripName);

            return Ok(trip.Stops);
        }
    }
}
