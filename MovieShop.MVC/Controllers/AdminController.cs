using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    //[Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public AdminController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> CreateMovie()
        {           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMovie(MovieDetailsResponseModel movieDetailsResponseModel)
        {
            var movie = movieDetailsResponseModel;
            //var movieCreated = _movieRepository.AddAsync(movie);
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
