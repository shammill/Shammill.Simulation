using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shammill.Simulation.Content;
using Shammill.Simulation.Hubs;
using System.Threading.Tasks;


namespace Shammill.Simulation
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.AddJsonFile("appsettings.json", true, true);
            builder.Configuration.AddEnvironmentVariables();

            // Add services to the container.
            builder.Services.AddHostedService<SimulationRunner>();
            builder.Services.AddSignalR().AddJsonProtocol(options => {
                options.PayloadSerializerOptions.IncludeFields = true;
                options.PayloadSerializerOptions.PropertyNamingPolicy = null;
            });
            builder.Services.AddSingleton(new SimArea());

            builder.Logging.AddConsole();
            builder.Logging.SetMinimumLevel(LogLevel.Trace);
            var app = builder.Build();

            // Map SignalR Hub
            app.MapHub<SignalRHub>("/signalr");

            // Use the logger for any necessary logging
            app.Logger.LogInformation("Application started.");

            await app.RunAsync();
        }
    }
}

