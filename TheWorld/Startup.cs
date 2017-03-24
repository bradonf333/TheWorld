using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TheWorld.Services;
using Microsoft.Extensions.Configuration;
using TheWorld.Models;

namespace TheWorld
{
    public class Startup
    {
        private IHostingEnvironment _env;
        private IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            _env = env;

            /* 
             * Builds the different parts of the config
             * -env can tell if we are in a dev or prod environment
             * 
             * AddJsonFile is a config file where we can set certain elements.
             *  -Currently it just has the email in it.
             *  
             * AddEnvironmentVariables is not currently being used. 
             *  -This is something that can be used if you ever want to override the
             *   config.json variables.
             *  -This is the value from the properties. if you right click the project and
             *   go to properties you can set Environment Variables
             */
            var builder = new ConfigurationBuilder()
                .SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();

            _config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);

            // Can check if the env is a development machine or can test for a made up env created by company
            if (_env.IsDevelopment() || _env.IsEnvironment("Testing"))
            {
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                // Real mail implement
            }

            // This makes the WorldContext Injectable to different areas
            services.AddDbContext<WorldContext>();

            // Makes the WorldContextSeedData available for use to use
            // Dependency injection layer
            services.AddTransient<WorldContextSeedData>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory,
            WorldContextSeedData seeder)
        {
            // Checks to make sure this is a developement machine (check using alt+enter
            // If so then we can show the exception page which is easier to debug
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Changes the default files request
            //app.UseDefaultFiles();
            // Static files finds the files
            app.UseStaticFiles();

            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });

            // Calls the seeder.
            // Since Configure is not asynchronusneed to use the Wait command to make it act asynchronus
            // Will wait until it gets a return
            seeder.EnsureSeedData().Wait();
        }
    }
}
