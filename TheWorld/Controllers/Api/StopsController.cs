using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.ViewModel;

namespace TheWorld.Controllers.Api
{
    [Route("/api/trips/{tripName}/stops")] // Set up the route at the class level so it can be used throughout
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
        [HttpGet("")]
        public IActionResult Get(string tripName)
        {
            try
            {
                // Since we are dealing with a Stop we need the trip name
                var trip = _repository.GetTripByName(tripName);

                return Ok(Mapper.Map<IEnumerable<StopViewModel>>(trip.Stops.OrderBy(s => s.Order).ToList()));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get stops: {0}", ex);
            }

            // If the first return is not reached then return a bad request
            return BadRequest("Failed to get stops");
        }

        /*
         * ==============================================
         *   -- Add a new stop for a specific trip --
         * ==============================================
         */
        [HttpPost("")]
        public IActionResult Post(string tripName, [FromBody]StopViewModel vm)
        {
            try
            {
                // Check if the VM is valid
                if (ModelState.IsValid)
                {
                    // Create new Stop using the AutoMapper
                    var newStop = Mapper.Map<Stop>(vm);
                    // Lookup the Geocodes

                    // Save to the database
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get stops: {0}", ex);
            }

            // If the first return is not reached then return a bad request
            return BadRequest("Failed to get stops");
        }
    }
}
