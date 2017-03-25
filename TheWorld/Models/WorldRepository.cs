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

        /// <summary>
        /// Gets all the trips from the database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Trip> GetAllTrips()
        {
            // Can think of this as a query
            return _context.Trips.ToList();
        }
    }
}
