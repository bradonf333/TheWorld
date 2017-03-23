using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TheWorld.Models
{
    public class WorldContext : DbContext
    {
        private IConfigurationRoot _config;

        /// <summary>
        /// Can use the configuration information that is created in Startup.cs
        /// </summary>
        /// <param name="config"></param>
        public WorldContext(IConfigurationRoot config, DbContextOptions options) : base()
        {
            _config = config;
        }

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Stop> Stops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Tell DbContext to use an SqlServer database
            // Gets the SqlConnectionString from the config.json file
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:WorldContextConnection"]);
        }
    }
}
