using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            // Can easily return in case of a failure   
            var result = new GeoCoordsResult()
            {
                Success = false,
                Message = "Failed to get coordinates"
            };

            // Info needed to make calls to bingMaps to get the long and lat
            var apiKey = "";
            var encodedName = WebUtility.UrlEncode(name);
            var url = $"http://dev.virtualearth.net/REST/v1/Locations?q={encodedName}&key={apiKey}";
        }
        
    }
}
