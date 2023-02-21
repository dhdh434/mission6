using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _blahContext.Categories.ToList();
            return View(new movieInput());
        }

        [HttpPost]
        public IActionResult addMovies(movieInput ar)
        {
            if (ModelState.IsValid)
            {
                _blahContext.Add(ar);
                _blahContext.SaveChanges();
                return View("submitted", ar);
            }
            else
            {
                ViewBag.Categories = _blahContext.Categories.ToList();
                return View(ar);
            }

            
        }
        public IActionResult myPodcasts()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            var movieToAdd = _blahContext.moviesAdded
                .Include(x => x.Category)
                .ToList();

            return View(movieToAdd);
        }

        [HttpGet]
        public IActionResult Edit(int movieId)
        {
            ViewBag.Categories = _blahContext.Categories.ToList();
            var movieEdited = _blahContext.moviesAdded.Single(x => x.MovieId == movieId);

            return View("addMovies", movieEdited);
        }

        [HttpPost]
        public IActionResult Edit(movieInput blah)
        {

            if (ModelState.IsValid)
            {
                _blahContext.Update(blah);
            _blahContext.SaveChanges();

            return RedirectToAction("MovieList");
            }

            else
            {
                ViewBag.Categories = _blahContext.Categories.ToList();
                return View("addMovies", blah);
            }

        }

        [HttpGet]
        public IActionResult Delete(int movieId)
        {
            var movie = _blahContext.moviesAdded.Single(x => x.MovieId == movieId);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(movieInput mo)
        {
            _blahContext.moviesAdded.Remove(mo);
            _blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
