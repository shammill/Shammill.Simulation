using System;
using System.Threading.Tasks;


namespace Shammill.Simulation.Hubs
{
    public interface ISignalRHub
    {
        Task OnConnectedAsync();

        Task OnDisconnectedAsync(Exception exception);
    }
}
