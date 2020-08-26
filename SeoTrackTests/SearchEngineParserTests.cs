using Moq;
using NUnit.Framework;
using SeoTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoTrackTests
{
    //TODO: Add test for page address calculation
    //TODO: Add tests for page parsers
    class SearchEngineParserTests
    {
        static readonly SearchEngineParameters DefaultParameters = new SearchEngineParameters { SearchEngineName = "Name", UrlTemplate = "{0}" };

        [Test]
        public async Task TestNoLinks() // making sure GetPositions() returns 0 when no results found
        {
            var urlFinder = new Mock<ISearchPageParser>();
            urlFinder
                .Setup(finder => finder.GetLinks(It.IsAny<string>()))
                .Returns(new string[] { "some site" });

            var engineParser = new SearchEngineParser(DefaultParameters, Mock.Of<IPageLoader>(), urlFinder.Object);

            var positions = await engineParser.GetPositions("", "non-existing site", 100);

            Assert.That(positions.Count() == 1);
            Assert.That(positions.First() == 0);
        }

        [Test]
        public async Task TestSearchLimit() // making sure parsers stops after search limit is reached
        {
            string siteUrl = "https://somesite.com";
            int searchLimit = 50;

            var urlFinder = new Mock<ISearchPageParser>();
            urlFinder
                .Setup(finder => finder.GetLinks(It.IsAny<string>()))
                .Returns(new string[] { siteUrl, siteUrl, siteUrl });

            var engineParser = new SearchEngineParser(DefaultParameters, Mock.Of<IPageLoader>(), urlFinder.Object);

            var positions = await engineParser.GetPositions("", siteUrl, searchLimit);

            Assert.That(positions.Count() == searchLimit);
        }

        [Test]
        public void TestSearchEngineName() // making sure parsers respects given name
        {
            var engineParser = new SearchEngineParser(DefaultParameters, Mock.Of<IPageLoader>(), Mock.Of<ISearchPageParser>());

            Assert.That(engineParser.SearchEngineName == DefaultParameters.SearchEngineName);
        }
    }
}
