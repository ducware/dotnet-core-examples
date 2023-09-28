namespace SignalR.API.Clients
{
    public interface INotificationClient
    {
        Task ReceiveNotification(string message);
    }
}
