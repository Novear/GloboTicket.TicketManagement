using GloboTicket.TicketManagement.Identity.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Api
{
    public class Program
    {
        public async static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            // this logger is the Serilog Logger 
            // it is configured thorugh out the application configuration 
            // appsettings.json
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                // the interval at which logging will roll over into a new file
                .WriteTo.File("Log/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            // so for now Serilog is configured as as a logging provider 
            // go to email service to implement logging 
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

                    await Identity.Seed.UserCreator.SeedAsync(userManager);
                    Log.Information("Application starting");
                }
                catch (Exception ex)
                {

                    Log.Warning(ex, "An error occured while starting the application");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
