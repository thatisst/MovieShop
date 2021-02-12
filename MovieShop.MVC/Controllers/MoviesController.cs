using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        //https://localhost:44363/Movies/Index

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details()
        {
            //By defaul when u have return view()
            // u can change that
            //return View("Testing");
            return View();
        }

        [HttpGet]
        public IActionResult TopRevenueMovies()
        {
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
