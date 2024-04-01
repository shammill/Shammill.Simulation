using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseRouting();

            // Map SignalR Hub
            app.MapHub<UpdateHub>("/chatHub");

            app.Run();
        }
    }
}

