using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SeoTrack.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetValues(string request)
        {
            var res = new ResultObj[] { new ResultObj { EngineName = request, Entries = new int[] {1,2,3 } }, new ResultObj { EngineName = "e2", Entries = new int[] { 4, 5, 6 } } };
            return Ok(res);
        }
    }

    public class ResultObj
    {
        public string EngineName { get; set; }
        public IEnumerable<int> Entries { get; set; }
    }

}
