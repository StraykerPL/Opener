using Opener.Models;
using System.Diagnostics;

namespace Opener.Starters
{
    public sealed class AppsStarter : IAppsStarter
    {
        private readonly IProcessCreationProvider _processCreationProvider;

        public AppsStarter(IProcessCreationProvider processCreationProvider)
        {
            _processCreationProvider = processCreationProvider;
        }

        public ICollection<Process> Start(ICollection<string> args)
        {
            var appsEntries = args.ToList();
            var processes = new List<Process>();

            foreach (var appPath in appsEntries)
            {
                processes.Add(_processCreationProvider.Create(appPath));
            }

            return processes;
        }
    }
}