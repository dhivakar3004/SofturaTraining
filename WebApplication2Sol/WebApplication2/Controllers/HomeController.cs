using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Sample()
        //{
           
        //    int num1 = Convert.ToInt32(HttpContext.Request.Form["txtFirst"].ToString());
        //    int num2 = Convert.ToInt32(HttpContext.Request.Form["txtSecond"].ToString());
        //    int result = num1 + num2;
        //    ViewBag.SumResult = result.ToString();
        //    return RedirectToAction("sumResult");            
        //}
        [HttpPost]
        [ActionName("Sample")]
        public IActionResult SamplePost()
        {
            int FirstNum = Convert.ToInt32(Request.Form["firstnum"]);
            int Secoundnum = Convert.ToInt32(Request.Form["secondnum"]);
            TempData["result"] = FirstNum + Secoundnum;
            return RedirectToAction("result");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
