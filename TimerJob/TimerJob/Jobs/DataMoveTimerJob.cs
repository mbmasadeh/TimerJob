using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TimerJob.Data;
using TimerJob.Services;

namespace TimerJob.Jobs
{
    public class DataMoveTimerJob : IHostedService, IDisposable
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;
        private Timer _timer;
        public IServiceProvider Services { get; }

        public DataMoveTimerJob(IServiceProvider service, IConfiguration configuation, ILogger<DataMoveTimerJob> logger)
        {
            _configuration = configuation;
            _logger = logger;
            Services = service;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting...");
            _timer = new Timer(Sync, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
            _timer.Change(0, Timeout.Infinite);
            return Task.CompletedTask;
        }

        private void Sync (object state)
        {
            try
            {
                using (var scope = Services.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<TimerContext>();
                    var serivce = new InfoService(context);
                    serivce.MoveData();
                    _timer.Change(TimeSpan.FromMinutes(10), TimeSpan.FromMinutes(30));
                    _logger.LogInformation("Sync Finshed at {Time}", DateTime.Now);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(0, ex, "Error in the log");
            }
        }


        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
