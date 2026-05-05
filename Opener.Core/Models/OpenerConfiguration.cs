using Opener.Constants;

namespace Opener.Models
{
    public sealed record OpenerConfiguration(
        string WebsitesFileDirectory = FileDirectoryConsts.WebsitesFileDirectory,
        string AppsFileDirectory = FileDirectoryConsts.AppsFileDirectory);
}
