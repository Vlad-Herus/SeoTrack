using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeoTrack.Services
{
    public class BingEngineParser : SearchEngineParser
    {
        public BingEngineParser(BingEngineParameters parameters, IPageLoader pageLoader, BingPageParser bingPageParser) 
            : base(parameters, pageLoader, bingPageParser)
        {
        }
    }
}
