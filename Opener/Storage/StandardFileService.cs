using Opener.Models;

namespace Opener.Storage
{
    public sealed class StandardFileService : IFileService
    {
        public ICollection<string> Read(string fileDir)
        {
            using var reader = new StreamReader(fileDir);
            var input = reader.ReadToEnd();
            reader.Close();
            var entries = input.Split('\n').ToList();

            return entries;
        }

        public void Write(string fileDir, ICollection<string> content)
        {
            throw new NotImplementedException();
        }
    }
}