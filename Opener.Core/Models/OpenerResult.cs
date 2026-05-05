using System.Diagnostics;

namespace Opener.Models
{
    public sealed record OpenerResult(
        IReadOnlyCollection<Process> WebsiteProcesses,
        IReadOnlyCollection<Process> AppProcesses)
    {
        public IReadOnlyCollection<Process> Processes => WebsiteProcesses.Concat(AppProcesses).ToList();
    }
}
