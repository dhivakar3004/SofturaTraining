using firstWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace firstWebApplication.Controllers
{
    
    public class HomeController : Controller
    {
        int[] arr = { 60, 50,44,35,59, 77, 89, 93, 97, 97, 85 };
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Name"] = "Dhiva";
            ViewData["Age"] = 21;
            ViewBag.CustomerPhoneNumber = 9078563412;
            ViewBag.Price = 11134.89;
            var numbers = arr.Where(num => num < 60);
            ViewData["scores"] = numbers;
            ViewBag.Scores = numbers;
            return View();
        }
        public IActionResult About()
        {
            ViewData["Name"] = "Dhiva";
            ViewData["Age"] = 21;
            ViewBag.CustomerPhoneNumber = 9078563412;
            ViewBag.Price = 11134.89;
            return View();
        }
        public IActionResult ShowPost()
        {
            Post post = new Post();
            post.Id = 101;
            post.PostText = "Check this out. Test Post";
            post.Category = "Text";
            return View(post);
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
