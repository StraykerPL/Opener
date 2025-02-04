using Opener.Models;
using Opener.Starters;

namespace Opener.UnitTests.Starters
{
    public sealed class WebsitesStarterUnitTests
    {
        private readonly Mock<IProcessCreationProvider> _processCreationProviderMock = new();

        private WebsitesStarter? _websitesStarter;

        [Fact]
        public void WebsitesStarterOpensSingleWebpageInGivenBrowser()
        {
            // Arrange
            var fakeProc = new ProcessStub();
            _processCreationProviderMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Returns(fakeProc);
            _websitesStarter = new WebsitesStarter(_processCreationProviderMock.Object);

            // Act
            var result = _websitesStarter.Start(["C:\\awsome-browser.exe", "https://awsome-website.com"]);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.StrictEqual(fakeProc, result.First());
        }

        [Fact]
        public void WebsitesStarterOpensManyWebpagesInGivenBrowser()
        {
            // Arrange
            var websitesNames = new List<string>()
            {
                "C:\\awsome-browser.exe",
                "https://awsome-website1.com",
                "https://awsome-website2.com",
                "https://awsome-website3.com"
            };
            var fakeProc = new ProcessStub();
            _processCreationProviderMock.Setup(x => x.Create(It.IsAny<string>(), It.IsAny<string>())).Returns(fakeProc);
            _websitesStarter = new WebsitesStarter(_processCreationProviderMock.Object);

            // Act
            var result = _websitesStarter.Start(websitesNames);

            // Assert
            Assert.NotNull(result);
            Assert.StrictEqual(fakeProc, result.First());
        }
    }
}