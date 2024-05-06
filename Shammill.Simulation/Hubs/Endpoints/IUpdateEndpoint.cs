using Shammill.Simulation.Components.Base;
using System;
using System.Numerics;
using System.Threading.Tasks;

namespace Shammill.LobbyManager.Hubs.Notifiers
{
    public interface IUpdateEndpoint
    {
        Task PlayerUpdate(PlayerShip ship);
    }
}