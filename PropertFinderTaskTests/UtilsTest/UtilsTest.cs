using PropertyFinderTask.Models;
using PropertyFinderTask.Util;
using System.Threading.Tasks;
using Xunit;

namespace PropertFinderTaskTests.ControllersTest
{
    public class UtilsTest
    {
        [Fact]
        public async Task TestFileRead_WrongPath_ReturnsFalseStatus()
        {
            bool isSuccess = FileUtil.ReadLocalFileAsync(UrlUtil.GetMockServerUrl("dummypath.html")).Result.IsSuccess;
            Assert.False(isSuccess);
        }

        [Fact]
        public async Task TestValidExtension_ValidExtension_ReturnsJSON()
        {
            FileType extension = UrlUtil.GetExtension("test.json");
            Assert.Equal(FileType.Json, extension);
        }

        [Fact]
        public async Task TestInvalidExtension_InvalidExtension_ReturnsPdf()
        {
            FileType extension = UrlUtil.GetExtension("test.pdf");
            Assert.Equal(FileType.Unknown, extension);
        }

        [Fact]
        public async Task TestInvalidURL_EmptyURL_ReturnsFalse()
        {
            bool isValid = UrlUtil.IsValidUrl(string.Empty);
            Assert.False(isValid);
        }

        [Fact]
        public async Task TestValidURL_ValidURL_ReturnsTrue()
        {
            bool isValid = UrlUtil.IsValidUrl("http://example.com/test.json");
            Assert.True(isValid);
        }

    }
}
