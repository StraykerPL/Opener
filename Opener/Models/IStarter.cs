using System.Diagnostics;

namespace Opener.Models
{
    public interface IStarter
    {
        ICollection<Process> Start(ICollection<string> args);
    }
}