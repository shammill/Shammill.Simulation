using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Shammill.Simulation.Components.Base;

namespace Shammill.Simulation.Hubs.Notifiers
{
    public interface IPlayerShipNotifier
    {
    }


    public class PlayerShipNotifier : IPlayerShipNotifier
    {
        IHubContext<SignalRHub> HubContext;
        public PlayerShipNotifier(IHubContext<SignalRHub> hubContext)
        {
            HubContext = hubContext;
        }

        public async Task Update(string userId, PlayerShip ship)
        {
            await HubContext.Clients.User(userId).SendAsync("PlayerShipUpdate", ship);
        }
    }
}
