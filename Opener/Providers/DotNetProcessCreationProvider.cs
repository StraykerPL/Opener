using Opener.Models;
using System.Diagnostics;
using System.Text;

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
                var builder = new StringBuilder();
                foreach (string arg in args)
                {
                    builder.Append(arg);
                    builder.Append(' ');
                }
                builder.Remove(builder.Length - 1, 1);

                return Process.Start(builder.ToString());
            }
        }
    }
}