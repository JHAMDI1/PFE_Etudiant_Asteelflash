using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Hubs
{
    [Authorize]
    public class NotificationHub : Hub<INotificationClient>
    {
    }

    public interface INotificationClient
    {
        Task ReceiveNotification(object notification);
    }
}
