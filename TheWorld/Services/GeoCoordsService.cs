using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Services
{
    public class GeoCoordsService
    {
        private ILogger<GeoCoordsService> _logger;

        // Ctor to initialize logger
        public GeoCoordsService(ILogger<GeoCoordsService> logger)
        {
            _logger = logger;
        }

        public async Task<GeoCoordsResult> GetCoordsAsync(string name)
        {
            // Create instance of GeoCoordResult with default values
            var result = new GeoCoordsResult()
            {
                Success = false,
                Message = "Failed to get coordinates"
            };
        }
        
    }
}
