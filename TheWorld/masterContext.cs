using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace TheWorld
{
    public partial class masterContext : DbContext
    {
        public IConfigurationRoot _config { get; private set; }

        /// <summary>
        /// Can use the configuration information that is created in Startup.cs
        /// </summary>
        /// <param name="config"></param>
        public masterContext(IConfigurationRoot config, DbContextOptions options) : base()
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:WorldContextConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}