using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Scorpion.SchoolManagement.NotificationService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = CreateHostBuilder(args).Build();
            
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var _ShutdownTime = Convert.ToInt32(hostContext.Configuration["ServiceConfig:ShutdownTime"]);
                    //builderContext
                    services.PostConfigure<HostOptions>((a) =>
                    {
                        a.ShutdownTimeout = TimeSpan.FromSeconds(_ShutdownTime);//Read From configuraiton
                    });
                    services.AddHostedService<MessageBroadcasterService>();//Service - 1 - Started first and stopped last
                    services.AddHostedService<FilePolingService>();//Service - 2 Started last and stopped first

                });
    }
}
