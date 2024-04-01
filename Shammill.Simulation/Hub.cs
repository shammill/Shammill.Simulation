using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Shammill.Simulation
{
    public class UpdateHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}