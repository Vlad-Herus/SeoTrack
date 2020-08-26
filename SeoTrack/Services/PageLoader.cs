using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SeoTrack.Services
{
    public class PageLoader : IPageLoader
    {
        public Task<string> LoadPage(string pageAddress)
        {
            var client = new HttpClient();
            return client.GetStringAsync(pageAddress);
        }
    }
}
