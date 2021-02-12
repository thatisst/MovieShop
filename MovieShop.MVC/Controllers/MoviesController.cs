using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieShop.Infrastructure.Services;
using MovieShop.Core.ServiceInterfaces;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        //https://localhost:44363/Movies/Index

        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
            _movieService = movieService;
        }
        //MovieService movieService = new MovieService();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details()
        {
            //By defaul when u have return view()
            // u can change that to views of other names
            //return View("Testing");
            return View();
        }

        [HttpGet]
        public IActionResult TopRevenueMovies()
        {
            var movies = _movieService.GetHighestGrossingMovies();
            return View();
        }

        [HttpGet]
        public IActionResult TopRatedMovies()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Genre(int genreId)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Reviews(int movieId)
        {
            return View();
        }
    }
}
