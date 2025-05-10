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
            const int TickIntervalMs = 250;
            Stopwatch stopWatch = new Stopwatch();
            while (!stoppingToken.IsCancellationRequested)
            {
                stopWatch.Start();

                ProcessActions();
                await BroadcastEntityUpdatesAsync();

                var computeTimeMs = stopWatch.Elapsed.Milliseconds;
                var computeTimeNanos = stopWatch.Elapsed.Nanoseconds;
                Console.WriteLine($"ComputeTimeMs: {computeTimeMs}ms {computeTimeNanos}ns");
                stopWatch.Stop();
                stopWatch.Reset();
                
                count++;
                Console.WriteLine($"Count: {count}");

                var delay = TickIntervalMs - computeTimeMs;
                if (delay < 0)
                    continue;
                else
                    await Task.Delay(delay, stoppingToken);
                // note: you HAVE TO delay or the signalr hub gets blocked.
                // would have to do some magic to avoid this.
            }
        }

        private void ProcessActions()
        {
            var actionsCount = 0;
            if (Actions.Queue.Count > 0)
                actionsCount = Actions.Queue.Count;
            while (actionsCount > 0)
            {
                var action = Actions.Queue.Dequeue();
                if (action.Type == ActionType.None)
                {

                }
                else if (action.Type == ActionType.Movement)
                {
                    var actor = SimArea.objects.Where(x => x.Id == action.ActorId).FirstOrDefault();
                    if (actor != null)
                    {
                        // for now lets just teleport to client coords and rotation, will do move advanced stuff later.
                        // Also want to check for speedhack by checking speed is within range.
                        Console.WriteLine($"Applying movement to {action.ActorId}, {action.Transform.Position}");
                        actor.Transform = action.Transform;
                    }
                }
                else if (action.Type == ActionType.Item)
                {
                    PlayerShip actor = SimArea.objects.FirstOrDefault(x => x.Id == action.ActorId) as PlayerShip;
                    var equipment = actor.Equipment[action.Gear];
                    if (action.Transform != null)
                    {
                        // use equipment at location
                    }
                    else if (action.SubjectId != null)
                    {
                        PlayerShip subject = SimArea.objects.FirstOrDefault(x => x.Id == action.SubjectId) as PlayerShip;
                        // use equipment on subject

                    }
                    //  update clients that action happened.
                }
                actionsCount = actionsCount - 1;
            }
        }

        private async Task BroadcastEntityUpdatesAsync()
        {
            // Per item send update to each client - unoptimized, will bundle multiple objects into single update.
            // This currently ends up being 16x16 (256) updates per tick, which is far too many.
            foreach (var entity in SimArea.objects)
            {
                entity.Update(1);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
                await HubContext.Clients.All.SendAsync("1", entity);
            }
        }
    }
}