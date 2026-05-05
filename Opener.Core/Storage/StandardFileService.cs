using Opener.Constants;
using Opener.Models;

namespace Opener.Storage
{
    public sealed class StandardFileService : IFileService
    {
        public ICollection<string> Read(string fileDir)
        {
            if (!File.Exists(fileDir))
            {
                throw new ArgumentException(ExceptionMessages.InvalidPathMessage, nameof(fileDir));
            }

            using var reader = new StreamReader(fileDir);
            var input = reader.ReadToEnd();
            reader.Close();
            var entries = input.Split(Environment.NewLine).ToList();

            return entries;
        }

        public void Write(string fileDir, ICollection<string> content)
        {
            throw new NotImplementedException();
        }
    }
}
