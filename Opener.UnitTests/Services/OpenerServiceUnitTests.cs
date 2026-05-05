using Opener.Models;
using Opener.Services;
using System.Diagnostics;

namespace Opener.UnitTests.Services
{
    public sealed class OpenerServiceUnitTests
    {
        private readonly Mock<IFileService> _fileServiceMock = new();

        private readonly Mock<IWebsitesStarter> _websitesStarterMock = new();

        private readonly Mock<IAppsStarter> _appsStarterMock = new();

        [Fact]
        public void OpenStartsConfiguredWebsitesAndApps()
        {
            // Arrange
            var websitesFile = Path.GetTempFileName();
            var appsFile = Path.GetTempFileName();
            var websiteProcesses = new List<Process> { new ProcessStub() };
            var appProcesses = new List<Process> { new ProcessStub(), new ProcessStub() };
            var websiteEntries = new List<string> { "browser.exe", "https://example.com" };
            var appEntries = new List<string> { "app.exe" };

            _fileServiceMock.Setup(x => x.Read(websitesFile)).Returns(websiteEntries);
            _fileServiceMock.Setup(x => x.Read(appsFile)).Returns(appEntries);
            _websitesStarterMock.Setup(x => x.Start(websiteEntries)).Returns(websiteProcesses);
            _appsStarterMock.Setup(x => x.Start(appEntries)).Returns(appProcesses);

            var openerService = new OpenerService(
                _fileServiceMock.Object,
                _websitesStarterMock.Object,
                _appsStarterMock.Object);

            try
            {
                // Act
                var result = openerService.Open(new OpenerConfiguration(websitesFile, appsFile));

                // Assert
                Assert.Equal(websiteProcesses, result.WebsiteProcesses);
                Assert.Equal(appProcesses, result.AppProcesses);
                Assert.Equal(3, result.Processes.Count);
            }
            finally
            {
                File.Delete(websitesFile);
                File.Delete(appsFile);
            }
        }

        [Fact]
        public void OpenIgnoresMissingConfigurationFiles()
        {
            // Arrange
            var openerService = new OpenerService(
                _fileServiceMock.Object,
                _websitesStarterMock.Object,
                _appsStarterMock.Object);

            // Act
            var result = openerService.Open(new OpenerConfiguration("missing-websites.txt", "missing-apps.txt"));

            // Assert
            Assert.Empty(result.WebsiteProcesses);
            Assert.Empty(result.AppProcesses);
            _fileServiceMock.Verify(x => x.Read(It.IsAny<string>()), Times.Never);
            _websitesStarterMock.Verify(x => x.Start(It.IsAny<ICollection<string>>()), Times.Never);
            _appsStarterMock.Verify(x => x.Start(It.IsAny<ICollection<string>>()), Times.Never);
        }
    }
}
