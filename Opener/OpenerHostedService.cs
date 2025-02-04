﻿using Microsoft.Extensions.Hosting;
using Opener.Constants;
using Opener.Models;

namespace Opener
{
    public sealed class OpenerHostedService : IHostedService
    {
        private readonly IFileService _fileService;

        private readonly IWebsitesStarter _websitesStarter;

        private readonly IAppsStarter _appsStarter;

        public OpenerHostedService(
            IFileService fileService,
            IWebsitesStarter websitesStarter,
            IAppsStarter appsStarter)
        {
            _fileService = fileService;
            _websitesStarter = websitesStarter;
            _appsStarter = appsStarter;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var websitesEntries = _fileService.Read(FileDirectoryConsts.WebsitesFileDirectory).ToList();
            var appsEntries = _fileService.Read(FileDirectoryConsts.AppsFileDirectory).ToList();

            _websitesStarter.Start(websitesEntries);
            _appsStarter.Start(appsEntries);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}