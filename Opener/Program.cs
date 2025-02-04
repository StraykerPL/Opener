using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Opener.Models;
using Opener.Providers;
using Opener.Starters;
using Opener.Storage;

namespace Opener
{
    internal class Program
    {
        private static void Main()
        {
            IHost host = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<IFileService, StandardFileService>();
                    services.AddScoped<IProcessCreationProvider, DotNetProcessCreationProvider>();
                    services.AddScoped<IWebsitesStarter, WebsitesStarter>();
                    services.AddScoped<IAppsStarter, AppsStarter>();
                    services.AddHostedService<OpenerHostedService>();
                })
                .UseConsoleLifetime()
                .Build();

            host.Start();
        }
    }
}