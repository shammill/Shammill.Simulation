using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Shammill.Simulation.Hubs;
using System.Threading.Tasks;


namespace Shammill.Simulation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSignalR();
            builder.Services.AddHostedService<SimulationRunner>();
            var app = builder.Build();


            // Map SignalR Hub
            app.MapHub<SignalRHub>("/signalr");

            app.Run();
        }
    }
}

