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

        public async Task EnsureSeedData()
        {

        }
    }
}
