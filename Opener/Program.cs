using Opener.Constants;
using Opener.Providers;
using Opener.Starters;
using Opener.Storage;

namespace Opener
{
    internal class Program
    {
        private static void Main()
        {
            var fileService = new StandardFileService();
            var processProvider = new DotNetProcessCreationProvider();

            var websitesStarter = new WebsitesStarter(processProvider);
            var appsStarter = new AppsStarter(processProvider);

            var websitesEntries = fileService.Read(FileDirectoryConsts.WebsitesFileDirectory).ToList();
            var appsEntries = fileService.Read(FileDirectoryConsts.AppsFileDirectory).ToList();

            websitesStarter.Start(websitesEntries);
            appsStarter.Start(appsEntries);
        }
    }
}