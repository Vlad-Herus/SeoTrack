using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeoTrack.Services
{
    public class SearchEngineParser : ISearchEngineParser
    {
        const int PAGE_LIMIT = 1000;

        private readonly SearchEngineParameters m_Parameters;
        private readonly IPageLoader m_PageLoader;
        private readonly ISearchPageParser m_SearchPageParser;

        public string SearchEngineName => m_Parameters.SearchEngineName;

        public SearchEngineParser(SearchEngineParameters parameters, IPageLoader pageLoader, ISearchPageParser searchPageParser)
        {
            m_Parameters = parameters;
            m_PageLoader = pageLoader;
            m_SearchPageParser = searchPageParser;
        }

        public async Task<IEnumerable<int>> GetPositions(string query, string seoTarget, int searchLimit)
        {
            int linksParsed = 0;
            int currentPageNumber = 1; // starting page number is 1
            List<int> targetLinkNumbers = new List<int>();

            while (linksParsed < searchLimit)
            {
                string formattedPageNumber = currentPageNumber.ToString("00");
                string pageAddress = string.Format(m_Parameters.UrlTemplate, formattedPageNumber);
                // we would add query to the page address here

                var page = await m_PageLoader.LoadPage(pageAddress);
                currentPageNumber++;

                var pageLinks = m_SearchPageParser.GetLinks(page);

                foreach (var link in pageLinks)
                {
                    linksParsed++;
                    if (link.StartsWith(seoTarget, StringComparison.CurrentCultureIgnoreCase))
                    {
                        targetLinkNumbers.Add(linksParsed);
                    }

                    if (linksParsed == searchLimit)
                    {
                        break;
                    }
                }

                // making sure we're not stuck in the infinite loop. 
                if (currentPageNumber >= PAGE_LIMIT)
                {
                    throw new Exception("Failed to search engine entries in a reasonable number of pages.");
                }
            }

            if (targetLinkNumbers.Any())
            {
                return targetLinkNumbers;
            }
            else
            {
                return new int[] { 0 }; // if no mentions of the seo target were found 0 must be displayed
            }
        }
    }
}
