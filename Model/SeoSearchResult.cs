using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeoTrack.Model
{
    public class SeoSearchResult
    {
        public string EngineName { get; set; }
        public IEnumerable<int> Entries { get; set; }
    }
}
