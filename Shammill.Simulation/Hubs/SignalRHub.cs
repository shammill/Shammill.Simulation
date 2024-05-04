using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Shammill.Simulation.Hubs
{
    public class SignalRHub : Hub<object>, ISignalRHub
    {
        public SignalRHub() : base()
        {
        }

        public override async Task OnConnectedAsync()
        {
            //await Clients.Caller.Connected(Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //await Clients.Caller.Disconnected(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
