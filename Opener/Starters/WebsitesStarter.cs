using Opener.Models;
using System.Diagnostics;
using System.Text;

namespace Opener.Starters
{
    public class WebsitesStarter : IWebsitesStarter
    {
        public ICollection<Process> Start(ICollection<string> args)
        {
            var websitesEntries = args.ToList();
            var browserPath = websitesEntries[0];
            websitesEntries.RemoveAt(0);

            var websiteLinks = new StringBuilder();
            foreach (var websiteLink in websitesEntries)
            {
                websiteLinks.Append(websiteLink + ' ');
            }

            return [Process.Start(browserPath, websiteLinks.ToString())];
        }
    }
}