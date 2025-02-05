using Opener.Models;
using System.Diagnostics;
using System.Text;

namespace Opener.Starters
{
    public sealed class WebsitesStarter : IWebsitesStarter
    {
        private const char LinksSeparator = ' ';

        private readonly IProcessCreationProvider _processCreationProvider;

        public WebsitesStarter(IProcessCreationProvider processCreationProvider)
        {
            _processCreationProvider = processCreationProvider;
        }

        public ICollection<Process> Start(ICollection<string> args)
        {
            var websitesEntries = args.ToList();
            var browserPath = websitesEntries[0];
            websitesEntries.RemoveAt(0);

            var websiteLinks = new StringBuilder();
            foreach (var websiteLink in websitesEntries)
            {
                websiteLinks.Append(websiteLink.Replace(Environment.NewLine, string.Empty));

                if (websitesEntries.IndexOf(websiteLink) != websitesEntries.Count - 1)
                {
                    websiteLinks.Append(LinksSeparator);
                }
            }

            return [_processCreationProvider.Create(browserPath, websiteLinks.ToString())];
        }
    }
}