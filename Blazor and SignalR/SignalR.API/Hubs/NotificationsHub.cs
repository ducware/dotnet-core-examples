using Microsoft.AspNetCore.SignalR;
using SignalR.API.Clients;

namespace SignalR.API.Hubs
{
    public class NotificationsHub : Hub<INotificationClient>
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.Client(Context.ConnectionId)
                .ReceiveNotification($"Thank you connecting {Context.User?.Identity?.Name}");

            await base.OnConnectedAsync();
        }
    }
}
