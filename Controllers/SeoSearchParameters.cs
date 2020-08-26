using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace SeoTrack.Controllers
{
    public class SeoSearchParameters
    {
        public string SeoTarget { get; }
        public int SeoSearchLimit { get; }

        public SeoSearchParameters(string seoTarget, int seoSearchLimit)
        {
            SeoTarget = seoTarget;
            SeoSearchLimit = seoSearchLimit;
        }
    }
}
