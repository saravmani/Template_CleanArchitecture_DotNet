using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Scorpion.SchoolManagement.HealthCheck.CustomHealthLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scorpion.SchoolManagement.HealthCheck
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddHealthChecks()
                //.AddCheck("FTP Connectivity Check", new FTPConnectivityCheck("ftpKey"), tags: new[] { "InfoLevel" })
                //.AddSqlite("Data Source = StudentManagement.db", timeout: TimeSpan.FromSeconds(30), failureStatus: HealthStatus.Unhealthy, name: "Student DB Connectivity Check", tags: new[] { "CriticalCheck" })
                //.AddUrlGroup(new Uri("/api/student"), "Student Management API", HealthStatus.Unhealthy, tags: new[] { "CriticalCheck" })
                
                .AddCheck("Custom heal check-1", () =>
                {
                    // Keep custom logic here to return healthy or unhealthy
                    return HealthCheckResult.Healthy();
                    //return HealthCheckResult.Unhealthy();
                }, tags: new[] { "InfoLevel" });

            services.AddHealthChecksUI().AddInMemoryStorage();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                // To check health of HealthMonitor Service
                endpoints.MapHealthChecks("/healthServiceAlive", new HealthCheckOptions
                {
                    Predicate = (a) => a.Tags.Count == 0,
                    AllowCachingResponses = false

                });
                
                //To Check critical services
                endpoints.MapHealthChecks("/health/CriticalCheck", new HealthCheckOptions
                {
                    Predicate = (a) => a.Tags.Contains("CriticalCheck"),
                    AllowCachingResponses = false
                });
                endpoints.MapHealthChecks("/health/InfoLevel", new HealthCheckOptions
                {
                    Predicate = (a) => a.Tags.Contains("InfoLevel"),
                    AllowCachingResponses = false
                });


                //Used By HealthCheck UI.. this will monitor all the health check urls
                endpoints.MapHealthChecks("/health/Complete", new HealthCheckOptions
                {
                    Predicate = a => true,
                    ResponseWriter=UIResponseWriter.WriteHealthCheckUIResponse,
                    AllowCachingResponses = false

                });

            });

            app.UseHealthChecksUI();
        }
    }
}
