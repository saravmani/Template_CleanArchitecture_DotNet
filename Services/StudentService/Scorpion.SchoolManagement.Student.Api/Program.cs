using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Scorpion.SchoolManagement.Student.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
                //.ConfigureLogging((builderContext, logBuilder) =>
                //{
                //    logBuilder.AddConfiguration(builderContext.Configuration.GetSection("Logging"));
                //    logBuilder.AddEventLog();
                //    logBuilder.AddConsole();
                //    logBuilder.AddDebug();                
                //});
            
    }
}
