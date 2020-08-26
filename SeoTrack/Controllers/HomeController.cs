using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeoTrack.Model;
using SeoTrack.Services;

namespace SeoTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly SeoSearchParameters m_SeoSearchParameters;
        private readonly IEnumerable<ISearchEngineParser> m_SearchEngineParsers;

        public HomeController(SeoSearchParameters seoSearchParameters, IEnumerable<ISearchEngineParser> searchEngineParsers)
        {
            m_SeoSearchParameters = seoSearchParameters;
            m_SearchEngineParsers = searchEngineParsers;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetLinkIds(string query)
        {
            var searches = m_SearchEngineParsers.ToDictionary(
                parser => parser,
                parser => parser.GetPositions(query, m_SeoSearchParameters.SeoTarget, m_SeoSearchParameters.SeoSearchLimit));

            await Task.WhenAll(searches.Values);

            List<SeoSearchResult> result = new List<SeoSearchResult>();

            foreach (var search in searches)
            {
                result.Add(new SeoSearchResult
                {
                    EngineName = search.Key.SearchEngineName,
                    Entries = await search.Value
                });
            }

            return Ok(result.ToArray());
        }
    }
}
