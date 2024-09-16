using System;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Shammill.LobbyManager.Hubs.Notifiers;
using Shammill.Simulation.Components;
using Shammill.Simulation.Components.Base;
using Shammill.Simulation.Content;
using Shammill.Simulation.Models;

namespace Shammill.Simulation.Hubs
{
    public class SignalRHub : Hub
    {
        private Actions Actions;
        private SimArea SimArea;
        public SignalRHub(SimArea simArea , Actions actions) : base()
        {
            Actions = actions;
            SimArea = simArea;
        }

        public override async Task OnConnectedAsync()
        {
            // ISSUE: the first time a client connects there is a significant delay in the whole app. Maybe DI? Investigate not lazy loading, and frontloading all things. TODO

            //await Clients.Caller.Connected(Context.ConnectionId);
            await base.OnConnectedAsync();
            Console.WriteLine("CLIENT CONNECTED");
            var player = new PlayerShip(new Guid("629a9e83-e428-43c9-bfcf-10a15b66c931"), Guid.NewGuid(), new Transform(Vector3.Zero, Vector3.Zero, Vector3.Zero, new Quaternion(0, 0, 0, 0), 1f));
            // TODO Load from DB.

            SimArea.objects.Add(player);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            //await Clients.Caller.Disconnected(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        [HubMethodName("PlayerAction")]
        public async Task PlayerAction(SimulationAction action)
        {
            Console.WriteLine("CLIENT UPDATE");
            Actions.Queue.Enqueue(action);
        }

        //[HubMethodName("PlayerUpdate")]
        //public async Task PlayerUpdate(PlayerShip ship)
        //{
        //    Console.WriteLine("CLIENT UPDATE");
        //    //Console.WriteLine(ship.Transform.Position);
        //    //simArea.objects.Add(ship);
        //}

        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
