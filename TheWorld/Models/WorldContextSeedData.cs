using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;

        /// <summary>
        /// WorldContext is where we have our optionsBuilder.UseSqlServer & our connection string
        /// </summary>
        /// <param name="context"></param>
        public WorldContextSeedData(WorldContext context)
        {
            _context = context;
        }

        //
        public async Task EnsureSeedData()
        {
            // Check to see if any Trips exist in the database
            if(!_context.Trips.Any())
            {
                // Create a US Trip instance
                var usTrip = new Trip()
                {
                    DateCreated = DateTime.UtcNow,
                    Name = "US Trip",
                    Stops = new List<Stop>()
                    {

                    }
                };

                // The usTrip instance to our database
                _context.Trips.Add(usTrip);
            }
        }
    }
}
