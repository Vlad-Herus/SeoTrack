using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeoTrack.Services
{
    public class GooglePageParser : ISearchPageParser
    {
        const string LINK_GROUP_NAME = "lnk";
        static readonly string GOOGLE_REGEX = $"div class=\"g\".+?href=\"(?'{LINK_GROUP_NAME}'[^\"]+)\"";
        private readonly Regex GoogleRegex = new Regex(GOOGLE_REGEX, RegexOptions.Compiled);

        public IEnumerable<string> GetLinks(string pageContent)
        {
            var matches = GoogleRegex.Matches(pageContent);
            return matches
                .Select(match => match.Groups[LINK_GROUP_NAME].Value);
        }
    }
}
