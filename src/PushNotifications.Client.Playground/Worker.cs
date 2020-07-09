using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PushNotifications.Client.Net;

namespace PushNotifications.Client.Playground
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly PushNotificationsHttpClient _httpClient;

        public Worker(ILogger<Worker> logger, PushNotificationsHttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var zz = _httpClient.Discovery();

            _logger.LogDebug(string.Join("/n", zz.Result.Endpoints));
        }
    }
}
