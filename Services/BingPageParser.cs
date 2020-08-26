using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeoTrack.Services
{
    public class BingPageParser : ISearchPageParser
    {
        const string LINK_GROUP_NAME = "lnk";
        static readonly string BING_REGEX = $"li class=\"b_algo\".+?href=\"(?'{LINK_GROUP_NAME}'[^\"]+)\"";
        private readonly Regex BingRegex = new Regex(BING_REGEX, RegexOptions.Compiled);
        
        public IEnumerable<string> GetLinks(string pageContent)
        {
            var matches = BingRegex.Matches(pageContent);
            return matches
                .Select(match => match.Groups[LINK_GROUP_NAME].Value);
        }
    }
}
