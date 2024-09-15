using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shammill.Simulation.Components;
using Shammill.Simulation.Components.Base;
using Shammill.Simulation.Content;
using Shammill.Simulation.Hubs;
using Shammill.Simulation.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Shammill.Simulation
{

    public class SimulationRunner : BackgroundService
    {
        private readonly IHubContext<SignalRHub> HubContext;
        private SimArea SimArea;
        private Actions Actions;

        public SimulationRunner(IHubContext<SignalRHub> hubContext, SimArea simArea, Actions actions)
        {
            HubContext = hubContext;
            SimArea = simArea;
            Actions = actions;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int count = 0;
            Stopwatch stopWatch = new Stopwatch();
            while (!stoppingToken.IsCancellationRequested)
            {
                stopWatch.Start();
                foreach (var action in Actions.Queue)
                {
                    if (action.Type == ActionType.None)
                    {

                    }
                    else if (action.Type == ActionType.Movement)
                    {
                        var actor = SimArea.objects.Where(x => x.Id == action.ActorId).FirstOrDefault();
                        if (actor != null)
                        {
                            // for now lets just teleport to client coords, will do move advanced stuff later.
                            // Also want to check for speedhack by checking speed is within range.
                            // probably need the whole transform. TODO.
                            actor.Transform.Position = action.Position;
                        }
                    }
                    else if (action.Type == ActionType.Item)
                    {

                    }

                    //var subject = SimArea.objects.FirstOrDefault(x => x.Id == action.SubjectId);
                    //if (subject.GetType() == typeof(PlayerShip))
                    //{

                    //}
                    // TODO apply action to thing.
                }

                // Per item send update to each client - unoptimized, will bundle multiple objects into single update.
                // This currently ends up being 16x16 (256) updates per tick, which is far too many.
                foreach (var entity in SimArea.objects)
                {
                    entity.Update(1);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                    await HubContext.Clients.All.SendAsync("ReceiveMessage", entity);
                }

                var computeTimeMs = stopWatch.Elapsed.Milliseconds;
                var computeTimeNanos = stopWatch.Elapsed.Nanoseconds;
                Console.WriteLine($"ComputeTimeMs: {computeTimeMs}");
                Console.WriteLine($"ComputeTimeNano: {computeTimeNanos}");
                stopWatch.Stop();
                stopWatch.Reset();
                
                count++;
                Console.WriteLine($"Count: {count}");

                var delay = 500 - computeTimeMs;
                if (delay < 0)
                    continue;
                else
                    await Task.Delay(delay, stoppingToken);
                // note: you HAVE TO delay or the signalr hub gets blocked.
                // would have to do some magic to avoid this.
            }
        }
    }
}