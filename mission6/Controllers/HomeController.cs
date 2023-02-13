using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private movieContext _blahContext { get; set; }

        public HomeController(ILogger<HomeController> logger, movieContext someName)
        {
            _logger = logger;
            _blahContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult addMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addMovies(movieInput ar)
        {
            _blahContext.Add(ar);
            _blahContext.SaveChanges();
            return View("submitted", ar);
        }
        public IActionResult myPodcasts()
        {
            return View();
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
