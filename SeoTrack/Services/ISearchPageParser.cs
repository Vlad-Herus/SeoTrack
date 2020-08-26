using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeoTrack.Services
{
    public interface ISearchPageParser
    {
        /// <summary>
        /// Parses given html page for links and returns them in order they appear on the page
        /// </summary>
        /// <param name="pageContent"></param>
        /// <returns></returns>
        IEnumerable<string> GetLinks(string pageContent);
    }
}
