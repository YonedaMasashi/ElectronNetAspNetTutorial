using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ElectronNetAspNetTutorial.Controllers
{
    public class HelloWorldController : Controller {

        public IActionResult Index() {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1) {
            // ViewData ディクショナリ オブジェクトには、ビューに渡されるデータが含まれている
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}