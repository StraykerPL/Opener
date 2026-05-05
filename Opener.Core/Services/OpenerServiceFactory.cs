using Opener.Models;
using Opener.Providers;
using Opener.Starters;
using Opener.Storage;

namespace Opener.Services
{
    public static class OpenerServiceFactory
    {
        public static IOpenerService CreateDefault()
        {
            var processCreationProvider = new DotNetProcessCreationProvider();

            return new OpenerService(
                new StandardFileService(),
                new WebsitesStarter(processCreationProvider),
                new AppsStarter(processCreationProvider));
        }
    }
}
