using Shammill.Simulation.Components.Base;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Shammill.LobbyManager.Hubs.Notifiers
{
    public class UpdateEndpoint : IUpdateEndpoint
    {
        public async Task PlayerUpdate(PlayerShip ship)
        {
            throw new NotImplementedException();
        }
    }
}