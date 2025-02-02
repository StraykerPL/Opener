using System.Diagnostics;

namespace Opener.Models
{
    public interface IProcessCreationProvider
    {
        Process Create(params string[] args);
    }
}