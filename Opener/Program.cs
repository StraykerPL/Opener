using Opener.Constants;
using Opener.Starters;
using Opener.Storage;

namespace Opener
{
    internal class Program
    {
        private static void Main()
        {
            var fileService = new StandardFileService();
            var websitesStarter = new WebsitesStarter();
            var appsStarter = new AppsStarter();

            var websitesEntries = fileService.Read(FileDirectoryConsts.WebsitesFileDirectory).ToList();
            var appsEntries = fileService.Read(FileDirectoryConsts.AppsFileDirectory).ToList();

            websitesStarter.Start(websitesEntries);
            appsStarter.Start(appsEntries);
        }
    }
}