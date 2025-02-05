using Opener.Models;
using System.Diagnostics;

namespace Opener.Providers
{
    public sealed class DotNetProcessCreationProvider : IProcessCreationProvider
    {
        public Process Create(params string[] args)
        {
            if (args.Length is 2)
            {
                return Process.Start(args[0], args[1]);
            }
            else
            {
                return Process.Start(args[0]);
            }
        }
    }
}