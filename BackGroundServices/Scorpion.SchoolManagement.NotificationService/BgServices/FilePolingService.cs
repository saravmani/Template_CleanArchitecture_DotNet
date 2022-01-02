using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Scorpion.SchoolManagement.NotificationService
{
    public class FilePolingService : BackgroundService
    {
        private readonly ILogger<FilePolingService> _logger;
        private readonly IHostApplicationLifetime _appLifeTime;
        public FilePolingService(ILogger<FilePolingService> logger, IHostApplicationLifetime appLifeTime)
        {
            _logger = logger;
            _appLifeTime = appLifeTime;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifeTime.ApplicationStopping.Register(() =>
            {
                _logger.LogInformation("Applicaiton is getting stopping");
                //Send this signal message to any monitoring applicaiton
            });
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {

                while (!stoppingToken.IsCancellationRequested)
                {
                    // SMS, Email, Webpush message sending logics
                    _logger.LogInformation("Message Sent Successfully!!: {time}", DateTimeOffset.Now);
                    await Task.Delay(5000, stoppingToken);
                }
            }
            catch (OperationCanceledException)// Will get called when task cancelled intermediatly (Ex: when we kill the process forcefully)
            {
                _logger.LogInformation("Operation Canceled externally");

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex.Message, ex);
            }
            finally
            {
                _appLifeTime.StopApplication();
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
