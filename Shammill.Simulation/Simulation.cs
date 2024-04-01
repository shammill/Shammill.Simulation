using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Shammill.Simulation;
using System;
using System.Threading;
using System.Threading.Tasks;

public class SimulationRunner : BackgroundService
{
    private readonly IHubContext<UpdateHub> _hubContext;

    public SimulationRunner(IHubContext<UpdateHub> hubContext)
    {
        _hubContext = hubContext;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var message = $"Server time is: {DateTime.Now}";
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", "Server", message);

            // Wait for some time before sending the next update (tick rate)
            await Task.Delay(1000, stoppingToken);
        }
    }
}