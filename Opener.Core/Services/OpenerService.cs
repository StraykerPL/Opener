using Opener.Models;
using System.Diagnostics;

namespace Opener.Services
{
    public sealed class OpenerService : IOpenerService
    {
        private readonly IFileService _fileService;

        private readonly IWebsitesStarter _websitesStarter;

        private readonly IAppsStarter _appsStarter;

        public OpenerService(
            IFileService fileService,
            IWebsitesStarter websitesStarter,
            IAppsStarter appsStarter)
        {
            _fileService = fileService;
            _websitesStarter = websitesStarter;
            _appsStarter = appsStarter;
        }

        public OpenerResult Open(OpenerConfiguration configuration)
        {
            var websiteProcesses = new List<Process>();
            var appProcesses = new List<Process>();

            if (File.Exists(configuration.WebsitesFileDirectory))
            {
                var websitesEntries = _fileService.Read(configuration.WebsitesFileDirectory).ToList();
                websiteProcesses.AddRange(_websitesStarter.Start(websitesEntries));
            }

            if (File.Exists(configuration.AppsFileDirectory))
            {
                var appsEntries = _fileService.Read(configuration.AppsFileDirectory).ToList();
                appProcesses.AddRange(_appsStarter.Start(appsEntries));
            }

            return new OpenerResult(websiteProcesses, appProcesses);
        }
    }
}
