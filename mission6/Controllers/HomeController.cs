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

        // home page controller
        public IActionResult Index()
        {
            return View();
        }

        // get for adding movies page controller
        [HttpGet]
        public IActionResult addMovies()
        {
            ViewBag.Categories = _blahContext.Categories.ToList();
            return View(new movieInput());
        }

        // post for adding movies page controller
        [HttpPost]
        public IActionResult addMovies(movieInput ar)
        {
            //check to make sure input is correct
            if (ModelState.IsValid)
            {
                // add the new changes
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
        
        //podcast controllers
        public IActionResult myPodcasts()
        {
            return View();
        }

        //movie list controller
        public IActionResult MovieList()
        {
            // bring in the list of movies
            var movieToAdd = _blahContext.moviesAdded
                .Include(x => x.Category)
                .ToList();

            return View(movieToAdd);
        }

        // get for editting
        [HttpGet]
        public IActionResult Edit(int movieId)
        {
            ViewBag.Categories = _blahContext.Categories.ToList();
            var movieEdited = _blahContext.moviesAdded.Single(x => x.MovieId == movieId);

            return View("addMovies", movieEdited);
        }

        // post for editting
        [HttpPost]
        public IActionResult Edit(movieInput blah)
        {
            //check the input and make sure its correct
            if (ModelState.IsValid)
            {
                //update the changes
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

        //delete the movie
        [HttpGet]
        public IActionResult Delete(int movieId)
        {
            var movie = _blahContext.moviesAdded.Single(x => x.MovieId == movieId);

            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(movieInput mo)
        {
            //remove the item
            _blahContext.moviesAdded.Remove(mo);
            _blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
