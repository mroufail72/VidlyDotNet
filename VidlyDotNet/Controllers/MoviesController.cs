﻿using System.Collections.Generic;
using System.Web.Mvc;
using VidlyDotNet.Models;
using VidlyDotNet.ViewModels;
using System.Data.Entity;
using System.Linq;
using VidlyDotNet.Migrations;
using System;
using System.Data.Entity.Validation;

namespace VidlyDotNet.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            //var movies = _context.Movies.Include(m => m.Genre).ToList();

            //return View(movies);

            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");

            return View("ReadOnlyList");

        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);

        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using VidlyDotNet.Models;
//using VidlyDotNet.ViewModels;

//namespace VidlyDotNet.Controllers
//{


//    public class MoviesController : Controller
//    {

//public class MoviesController : Controller
//{
// GET: Movies/Random
//public ViewResult Random()
//public ActionResult Random()
//{
//    var movie = new Movie() { Name = "Shrek!" };
//    return new ViewResult();
//    //return View(movie);
//    //return Content("Hello World!");
//    //return HttpNotFound();
//    //return new EmptyResult();
//    //return RedirectToAction("Index", "Home");
//    //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});


//}


//public ActionResult Random()
//{
//    var movie = new Movie() { Name = "Shrek!" };

//    //var viewResult = new ViewResult();
//    //viewResult.ViewData.Model
//    //ViewData["Movie"] = movie;
//    //ViewBag.Movie = movie;

//    var customers = new List<Customer>
//    {
//        new Customer { Name = "Customer 1" },
//        new Customer { Name = "Customer 1" }
//    };

//    var viewModel = new RandomMovieViewModel
//    {
//        Movie = movie,
//        Customers = customers
//    };

//    return View(viewModel);

//}

//public ActionResult Edit(int id)
//{
//    return Content("id-" + id);
//}

////movies
//public ActionResult Index(int? pageIndex, string sortBy)
//{
//    if (!pageIndex.HasValue)
//        pageIndex = 1;

//    if (String.IsNullOrWhiteSpace(sortBy))
//        sortBy = "Name";

//    return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
//}

//[Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
//public ActionResult ByReleaseDate(int year, int month)
//{
//    return Content(year + "/" + month);
//}

//    }
//}