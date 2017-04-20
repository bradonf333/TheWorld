using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class WorldRepository : IWorldRepository
    {
        private WorldContext _context;

        public WorldRepository(WorldContext context)
        {
            _context = context;
        }

        public void AddStop(string tripName, Stop newStop)
        {
            // Check to see if the trip is a valid trip and if so add the stop
            var trip = GetTripByName(tripName);

            // Since the stop is a related entity we need to add it to all appropriate locations
            if (trip != null)
            {
                trip.Stops.Add(newStop);        // Add the stop to the trip (Set the foreign key)
                _context.Stops.Add(newStop);    // Add the stop to the stop table (add the stop object itself)
            }
        }

        // Push to the context as a new object
        public void AddTrip(Trip trip)
        {
            _context.Add(trip);
        }

        /// <summary>
        /// Gets all the trips from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Trip> GetAllTrips()
        {
            // Can think of this as a query
            return _context.Trips.ToList();
        }

        /// <summary>
        /// Searches the Trips and returns the first one that has a name that matches the tripName parameter that is passed in
        /// </summary>
        /// <param name="tripName"></param>
        /// <returns></returns>
        public Trip GetTripByName(string tripName)
        {
            return _context.Trips
                // Dont just need the Trips we need the stops so include them here
                .Include(t => t.Stops)
                // Figures out which Trip to return. TripName is passed in so search all Trips until the correct name is found
                .Where(t => t.Name == tripName) 
                // Return the first tripName that matches the given tripName parameter
                .FirstOrDefault();
        }

        /// <summary>
        /// SaveChangesAsync will return an int with the number of rows affected
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
