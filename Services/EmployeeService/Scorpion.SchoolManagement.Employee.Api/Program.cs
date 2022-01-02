using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Scorpion.SchoolManagement.EmployeeManagement.Api
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
                    // GRPC Related Changes
                    //webBuilder.ConfigureKestrel(options =>
                    //{
                    //    options.ListenAnyIP(8000, listenOptions =>
                    //        listenOptions.Protocols = HttpProtocols.Http1);

                    //    options.ListenAnyIP(8001, listenOptions =>
                    //        listenOptions.Protocols = HttpProtocols.Http2);
                    //});
                    webBuilder.UseStartup<Startup>();
                });
    }
}
