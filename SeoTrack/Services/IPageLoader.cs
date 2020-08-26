using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeoTrack.Services
{
    public interface IPageLoader
    {
        /// <summary>
        /// Loads page from the given address on the internet
        /// </summary>
        /// <param name="pageAddress"></param>
        /// <returns></returns>
        Task<string> LoadPage(string pageAddress);
    }
}
