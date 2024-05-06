using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Shammill.Simulation.Hubs.Notifiers
{
    public interface IGenericNotifier
    {
        Task SendMessageToUser<T>(string userId, T message);
        Task SendMessageToGroup<T>(string group, T message);
        Task SendMessageToAll<T>(T message);
    }

    public class GenericNotifier : IGenericNotifier
    {
        IHubContext<SignalRHub> HubContext;
        public GenericNotifier(IHubContext<SignalRHub> hubContext)
        {
            HubContext = hubContext;
        }

        //[HubMethodName("SendMessageToUser")]
        public async Task SendMessageToUser<T>(string userId, T message)
        {
            await HubContext.Clients.User(userId).SendAsync("ReceiveMessage", message);
        }

        //[HubMethodName("SendMessageToGroup")]
        public async Task SendMessageToGroup<T>(string group, T message)
        {
            await HubContext.Clients.Groups(group).SendAsync("ReceiveMessage", message);
        }

        //[HubMethodName("SendMessageToAll")]
        public async Task SendMessageToAll<T>(T message)
        {
            await HubContext.Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
