using Opener.Models;
using Opener.Starters;
using System.Diagnostics;

namespace Opener.UnitTests.Starters
{
    public sealed class AppsStarterUnitTests
    {
        private readonly Mock<IProcessCreationProvider> _processCreationProviderMock = new();

        private AppsStarter? _appsStarter;

        [Fact]
        public void AppsStarterCreatesSingleAppProcess()
        {
            // Arrange
            var fakeProc = new Mock<Process>();
            _processCreationProviderMock.Setup(x => x.Create(It.IsAny<string>())).Returns(fakeProc.Object);
            _appsStarter = new AppsStarter(_processCreationProviderMock.Object);

            // Act
            var result = _appsStarter.Start(["awsome-app.exe"]);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.StrictEqual(fakeProc.Object, result.First());
        }

        //[Fact]
        //public void AppsStarterCreatesManyAppProcesses()
        //{
        //    // Arrange
        //    var procNames = new List<string>() { "awsome-app-1.exe", "awsome-app-2.exe", "awsome-app-3.exe" };
        //    var fakeProcs = procNames
        //        .Select(name =>
        //        {
        //            var mock = new Mock<Process>();
        //            var fakeStartInfo = new ProcessStartInfo
        //            {
        //                FileName = name,
        //            };
        //            mock.Setup(x => x.StartInfo).Returns(fakeStartInfo);
        //            _processCreationProviderMock.Setup(x => x.Create(name)).Returns(mock.Object);
        //            return mock;
        //        })
        //        .ToList();
        //    _appsStarter = new AppsStarter(_processCreationProviderMock.Object);

        //    // Act
        //    var result = _appsStarter.Start(procNames);

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.Equal(procNames.Count, result.Count);
        //    Assert.Equal(procNames, result.Select(x => x.StartInfo.FileName));
        //}
    }
}