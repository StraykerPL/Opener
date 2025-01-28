using Opener.Models;
using System.Diagnostics;

namespace Opener.Starters
{
    public class AppsStarter : IAppsStarter
    {
        public ICollection<Process> Start(ICollection<string> args)
        {
            var appsEntries = args.ToList();
            var processes = new List<Process>();

            foreach (var appsEntry in appsEntries)
            {
                processes.Add(Process.Start(appsEntry));
            }

            return processes;
        }
    }
}