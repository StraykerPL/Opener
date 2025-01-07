using System.Diagnostics;
using System.Text;

namespace Opener
{
    internal class Program
    {
        private static void Main()
        {
            var reader = new StreamReader("websites.txt");
            var websitesInput = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();

            var websitesEntries = websitesInput.Split('\n').ToList();
            var browserPath = websitesEntries[0];
            websitesEntries.RemoveAt(0);

            var websiteLinks = new StringBuilder();
            foreach (var websiteLink in websitesEntries)
            {
                websiteLinks.Append(websiteLink + ' ');
            }

            Process.Start(browserPath, websiteLinks.ToString());

            reader = new StreamReader("apps.txt");
            var appsInput = reader.ReadToEnd();
            reader.Close();
            reader.Dispose();

            var appsEntries = appsInput.Split('\n').ToList();
            foreach (var appsEntry in appsEntries)
            {
                Process.Start(appsEntry);
            }
        }
    }
}