using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeoTrack.Services
{
    public class SearchEngineParameters
    {
        /// <summary>
        /// Contains url with single parameter for page number to be used with string.Format. For single digit values must lead with 0
        /// </summary>
        public string UrlTemplate { get; set; }
        public string SearchEngineName { get; set; }
    }
}
