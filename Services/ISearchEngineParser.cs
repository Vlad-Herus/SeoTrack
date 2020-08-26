using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeoTrack.Services
{
    public interface ISearchEngineParser
    {
        string SearchEngineName { get; }

        /// <summary>
        /// Finds seoTarget in the search engine results for a given query and returns found positions
        /// </summary>
        /// <param name="query">Search Engine query</param>
        /// <param name="seoTarget">Number of search engine links to go through before stopping</param>
        /// <param name="SearchLimit">Link of the site to look for in the search engine results</param>
        /// <returns>Positions of the seoTarget in the search engine results</returns>
        Task<IEnumerable<int>> GetPositions(string query, string seoTarget, int searchLimit);
    }
}
