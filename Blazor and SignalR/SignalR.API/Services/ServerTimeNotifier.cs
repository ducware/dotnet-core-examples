using Microsoft.AspNetCore.SignalR;
using SignalR.API.Clients;
using SignalR.API.Hubs;

namespace SignalR.API.Services
{
    public class ServerTimeNotifier : BackgroundService
    {
        private static readonly TimeSpan Peroid = TimeSpan.FromSeconds(5);
        private readonly ILogger<ServerTimeNotifier> _logger;
        private readonly IHubContext<NotificationsHub, INotificationClient> _context;
        public ServerTimeNotifier(ILogger<ServerTimeNotifier> logger, IHubContext<NotificationsHub, INotificationClient> context)
        {
            _logger = logger;
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var timer = new PeriodicTimer(Peroid);

            while (!stoppingToken.IsCancellationRequested 
                && await timer.WaitForNextTickAsync(stoppingToken))
            {
                var dateTime = DateTime.Now;

                _logger.LogInformation("Excuting {Service} {Time}", nameof(ServerTimeNotifier), dateTime);

                await _context.Clients.All.ReceiveNotification($"Server time = {dateTime}");
            }
        }
    }
}
