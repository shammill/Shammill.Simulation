using System;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.LobbyManager.Hubs.Notifiers;
using Shammill.Simulation.Components.Base;
using Shammill.Simulation.Content;
using Shammill.Simulation.Models;

namespace Shammill.Simulation.Hubs
{
    public class SignalRHub : Hub
    {
        private Actions Actions;
        public SignalRHub(Actions actions) : base()
        {
            Actions = actions;
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

        //[HubMethodName("PlayerUpdate")]
        //public async Task PlayerUpdate(PlayerShip ship)
        //{
        //    // todo update running simulation.
        //}

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
