using Opener.Storage;

namespace Opener.UnitTests.Storage
{
    public sealed class StandardFileServiceUnitTests
    {
        private readonly StandardFileService _fileService = new();

        [Fact]
        public void WriteMethodIsNotUseable()
        {
            // Act and Assert
            Assert.Throws<NotImplementedException>(() => _fileService.Write("", []));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ReadMethodNotAcceptingEmptyFilePath(string? arg)
        {
            // Act and Assert
            Assert.Throws<ArgumentException>(() => _fileService.Read(arg!));
        }
    }
}