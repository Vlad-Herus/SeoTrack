using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeoTrack.Services
{
    public class GoogleEngineParser : SearchEngineParser
    {
        public GoogleEngineParser(GoogleEngineParameters parameters, IPageLoader pageLoader, GooglePageParser googlePageParser) 
            : base(parameters, pageLoader, googlePageParser)
        {
        }
    }
}
