using Microsoft.Extensions.Hosting;
using Opener.Models;

namespace Opener
{
    public sealed class OpenerHostedService : IHostedService
    {
        private readonly IOpenerService _openerService;

        public OpenerHostedService(IOpenerService openerService)
        {
            _openerService = openerService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _openerService.Open(new OpenerConfiguration());

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
