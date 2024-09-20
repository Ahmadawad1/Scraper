using Moq;
using PropertyFinderTask.Controllers;
using PropertyFinderTask.Services;
using PropertyFinderTask.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PropertFinderTaskTests.ControllersTest
{
    public class ScraperControllerTest
    {
        private readonly Mock<IScrapper> _scrapperMock;
        private readonly ScrapperController _controller;
        public ScraperControllerTest()
        {
            _scrapperMock = new Mock<IScrapper>();
            _controller = new ScrapperController(_scrapperMock.Object);
        }

        [Fact]
        public async Task TestMultilpeFiles_ValidAndInvalid_ReturnsDifferentResult()
        {
            string[] urls = new string[] {
                  "entity-123-456.json",
                  "test.pdf",
                  "product-123.html",
                  "empty.json"
            };
            var expectedScrapedResult = new List<Task<string>>
            {
                Task.FromResult("My Title"),
                Task.FromResult(Constants.UNSUPPORTED_TYPE),
                Task.FromResult("Title"),
                Task.FromResult(Constants.EMPTY_CONTENT)
            };

            _scrapperMock.Setup(s => s.Scrape(urls)).Returns(expectedScrapedResult);
            List<Task<string>> result = _scrapperMock.Object.Scrape(urls);

            Assert.Equal("My Title", await result[0]);
            Assert.Equal(Constants.UNSUPPORTED_TYPE, await result[1]);
            Assert.Equal("Title", await result[2]);
            Assert.Equal(Constants.EMPTY_CONTENT, await result[3]);
        }

        [Fact]
        public async Task TestSingleJsonFile_CorrectFile_ReturnsTitle()
        {
            string[] urls = new string[] { "entity-123-456.json" };
            var expectedScrapedResult = new List<Task<string>>
            {
                Task.FromResult("My Title")
            };

            _scrapperMock.Setup(s => s.Scrape(urls)).Returns(expectedScrapedResult);
            List<Task<string>> result = _scrapperMock.Object.Scrape(urls);
            Assert.Equal("My Title", await result[0]);
        }

        [Fact]
        public async Task TestSingleJsonFile_FileNotExistInMockServer_ReturnsInvalidUrl()
        {
            string[] urls = new string[] { "entity-123.json" };
            var expectedScrapedResult = new List<Task<string>>
            {
                Task.FromResult(Constants.FILE_NOT_FOUND)
            };

            _scrapperMock.Setup(s => s.Scrape(urls)).Returns(expectedScrapedResult);
            List<Task<string>> result = _scrapperMock.Object.Scrape(urls);
            Assert.Equal(Constants.FILE_NOT_FOUND, await result[0]);
        }

        [Fact]
        public async Task TestSingleJsonFile_FileExistButEmpty_ReturnsEmptyContentError()
        {
            string[] urls = new string[] { "empty.json" };
            var expectedScrapedResult = new List<Task<string>>
            {
                Task.FromResult(Constants.EMPTY_CONTENT)
            };

            _scrapperMock.Setup(s => s.Scrape(urls)).Returns(expectedScrapedResult);
            List<Task<string>> result = _scrapperMock.Object.Scrape(urls);
            Assert.Equal(Constants.EMPTY_CONTENT, await result[0]);
        }

        [Fact]
        public async Task TestSingleHtmlFile_CorrectFile_ReturnsTitle()
        {
            string[] urls = new string[] { "product-123.html" };
            var expectedScrapedResult = new List<Task<string>>
            {
                Task.FromResult("Title")
            };

            _scrapperMock.Setup(s => s.Scrape(urls)).Returns(expectedScrapedResult);
            List<Task<string>> result = _scrapperMock.Object.Scrape(urls);
            Assert.Equal("Title", await result[0]);
        }

        [Fact]
        public async Task TestUnsupportedFile_UnsupportedFormat_ReturnsUnsupportedError()
        {
            string[] urls = new string[] { "product-123.pdf" };
            var expectedScrapedResult = new List<Task<string>>
            {
                Task.FromResult(Constants.UNSUPPORTED_TYPE)
            };

            _scrapperMock.Setup(s => s.Scrape(urls)).Returns(expectedScrapedResult);
            List<Task<string>> result = _scrapperMock.Object.Scrape(urls);
            Assert.Equal(Constants.UNSUPPORTED_TYPE, await result[0]);
        }

        [Fact]
        public async Task TestEmptyURL_EmptyPayload_ReturnsInvalidURLError()
        {
            string[] urls = new string[] { "" };
            var expectedScrapedResult = new List<Task<string>>
            {
                Task.FromResult(Constants.INVALID_URL)
            };

            _scrapperMock.Setup(s => s.Scrape(urls)).Returns(expectedScrapedResult);
            List<Task<string>> result = _scrapperMock.Object.Scrape(urls);
            Assert.Equal(Constants.INVALID_URL, await result[0]);
        }
    }
}
