using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shammill.Simulation.Content;
using Shammill.Simulation.Hubs;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Shammill.Simulation
{

    public class SimulationRunner : BackgroundService
    {
        private readonly IHubContext<SignalRHub> _hubContext;
        private SimArea _simArea;

        public SimulationRunner(IHubContext<SignalRHub> hubContext, SimArea simArea)
        {
            _hubContext = hubContext;
            _simArea = simArea;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Stopwatch stopWatch = new Stopwatch();
            while (!stoppingToken.IsCancellationRequested)
            {
                stopWatch.Start();
                // todo a queue of actions users are taking. which apply to sim objects.
                foreach (var thing in _simArea.objects)
                {
                    thing.Update(1);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                    await _hubContext.Clients.All.SendAsync("ReceiveMessage", thing);
                }
                stopWatch.Stop();
                var computeTime = stopWatch.Elapsed.Milliseconds;
                stopWatch.Reset();
                Console.WriteLine($"ComputeTime: {computeTime}");

                Console.WriteLine("tick");

                var delay = 500 - computeTime;
                if (delay < 0)
                    continue;
                else
                    await Task.Delay(delay, stoppingToken);
                // note: you HAVE TO delay or the signalr hub gets blocked.
                // would have to do some multi-threading to avoid this.
            }
        }
    }
}