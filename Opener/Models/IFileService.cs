namespace Opener.Models
{
    public interface IFileService
    {
        ICollection<string> Read(string fileDir);

        void Write(string fileDir, ICollection<string> content);
    }
}