using Opener.Models;
using Opener.Starters;
using System.Diagnostics;

namespace Opener.UnitTests.Starters
{
    public sealed class AppsStarterUnitTests
    {
        private readonly Mock<IProcessCreationProvider> _processCreationProviderMock = new();

        private AppsStarter? _appsStarter;

        public AppsStarterUnitTests()
        {
            _processCreationProviderMock = new();
        }

        [Fact]
        public void AppsStarterCreatesSingleAppProcess()
        {
            // Arrange
            var fakeProc = new ProcessStub();
            _processCreationProviderMock.Setup(x => x.Create(It.IsAny<string>())).Returns(fakeProc);
            _appsStarter = new AppsStarter(_processCreationProviderMock.Object);

            // Act
            var result = _appsStarter.Start(["awsome-app.exe"]);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.StrictEqual(fakeProc, result.First());
        }

        [Fact]
        public void AppsStarterCreatesManyAppProcesses()
        {
            // Arrange
            var procNames = new List<string>() { "awsome-app-1.exe", "awsome-app-2.exe", "awsome-app-3.exe" };

            // "fakeProcs" variable must exist until the end of test, otherwise the last Assert will throw exception,
            // as mocked and stubbed objects exists under this variable.
            var fakeProcs = procNames.Select(name =>
            {
                var stub = new ProcessStub();
                var fakeStartInfo = new ProcessStartInfo
                {
                    FileName = name,
                };

                stub.StartInfo = fakeStartInfo;
                _processCreationProviderMock.Setup(x => x.Create(name)).Returns(stub);

                return stub;
            }).ToList();
            _appsStarter = new AppsStarter(_processCreationProviderMock.Object);

            // Act
            var result = _appsStarter.Start(procNames);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(procNames.Count, result.Count);
            Assert.Equal(procNames, result.Select(x => x.StartInfo.FileName));
        }
    }
}