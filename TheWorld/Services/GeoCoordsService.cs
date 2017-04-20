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
        
    }
}
