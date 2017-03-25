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
    // Centralized route for the Http requestes below
    [Route("api/trips")]

    public class TripsController : Controller
    {
        private IWorldRepository _repository;
        private ILogger<TripsController> _logger;

        // Inject the repository into this controller so it can be used in this class
        public TripsController(IWorldRepository repository, ILogger<TripsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

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
        /// Serializes as Json file. Returns all our trips via the repository var
        /// 
        /// Since we are getting multiple Trips we have to tell the mapper its IEnumberable Trips.
        /// Now it will map the collection of Trips.
        /// </summary>
        /// <returns>Json</returns>
        [HttpGet()]
        public IActionResult Get()
        {
            try
            {
                var results = _repository.GetAllTrips();

                return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get all Trips: {ex}");
                return BadRequest($"Error occured {ex}");
            }            
        }

        // When this url is called it will then call this method
        /// <summary>
        /// Posts data from the url
        /// 
        /// FromBody "model binds" the data from the body of the request and binds it to the
        /// object we have being passed in.
        /// 
        /// If we are passing in JSON then it will bind the property names from the JSON 
        /// to the property names of the object being passed in.
        /// </summary>
        /// <param name="trip"></param>
        /// <returns></returns>
        [HttpPost()]
        public IActionResult Post([FromBody]TripViewModel trip)
        {
            if (ModelState.IsValid)
            {
                // Save to the Database using the Mapper method
                var newTrip = Mapper.Map<Trip>(trip);

                return Created($"api/trips/{trip.Name}", Mapper.Map<TripViewModel>(newTrip));
            }

            return BadRequest(ModelState);
        }


        /* 
         * ========================================================================
         *      -- Return the Api as JSON
         *      
         *  This is how we set it up beforehand, but switched to IActionResult.
         *  -Wanted to keep this as an example.
         *  
         *  Using JSON we can't really return any errors.
         * ========================================================================
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
    }
}
