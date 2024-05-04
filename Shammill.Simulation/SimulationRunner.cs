using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Shammill.Simulation.Content;
using Shammill.Simulation.Hubs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Shammill.Simulation
{

    public class SimulationRunner : BackgroundService
    {
        private readonly IHubContext<SignalRHub> _hubContext;
        private SimArea _simArea = new SimArea();

        public SimulationRunner(IHubContext<SignalRHub> hubContext)
        {
            _hubContext = hubContext;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // todo a queue of actions users are taking. which apply to sim objects.
                foreach (var thing in _simArea.objects)
                {
                    thing.Update(1);
                }

                var message = $"Server time is: {DateTime.Now}";
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Server", message);

                // TODO TICK RATE (limit update rate.)
                //await Task.Delay(1000, stoppingToken);
            }
        }
    }
}