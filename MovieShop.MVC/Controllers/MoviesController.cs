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
        }
        //MovieService movieService = new MovieService();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            // call the Movie service that will call Movie Repository
            //return models not entities
            var movieDetails = await _movieService.GetMovieById(id);
            return View(movieDetails);
        }

        [HttpGet]
        public IActionResult TopRevenueMovies()
        {
            //var movies = _movieService.GetHighestGrossingMovies();
            return View();
        }

        [HttpGet]
        public IActionResult TopRatedMovies()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Genre(int id, int pageSize = 25, int pageNumber = 1)
        {
            var movies = await _movieService.GetMoviesByGenre(id, pageSize, pageNumber);
            return View("PagedIndex", movies);
        }

        [HttpGet]
        public IActionResult Reviews(int movieId)
        {
            return View();
        }
    }
}
