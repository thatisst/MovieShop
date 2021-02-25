using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")] //called: attribute routing
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMovieRepository _movieRepository;
        public MoviesController(IMovieService movieService, IMovieRepository movieRepository)
        {
            _movieService = movieService;
            _movieRepository = movieRepository;
        }

        [HttpGet]
        //[Route("~/")] // attribute based routing
        public async Task<IActionResult> Index()
        {

            return Ok();
        }

        [HttpGet]
        [Route("{Id}")] // attribute based routing
        public async Task<IActionResult> Index(int id)
        {
            var movie = await _movieRepository.GetByIdAsyc(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("{Id}/reviews")] // attribute based routing
        public async Task<IActionResult> GetReviewsByMovie(int id)
        {
            var movie = await _movieRepository.GetMovieReviews(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprevenue")] // attribute based routing
        public async Task<IActionResult> GetTopRevenueMovies()
        {
            var movies = await _movieService.GetTop25GrossingMovies();

            if (!movies.Any())
            {
                return NotFound("We did not find any movies");
            }
            return Ok(movies);

            // System.Text.Json in .NET Core 3 - System.Text.Json library
            // previous versions of .NET 1, 2 and previous older .NET Framework use Newtonsoft (3rd party library)
            // Serialization, convert your C# objects into JSON objects
            // De-serialization, convert JSON to C# (System.Text.Json in .NET CORE Framwork)
        }

        [HttpGet]
        [Route("toprated")] // attribute based routing
        public async Task<IActionResult> GetTopRatedMovies()
        {
            var movies = await _movieService.GetTopRatedMovies();

            if (!movies.Any())
            {
                return NotFound("We did not find any movies");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("genre/{genreId}")] // attribute based routing
        public async Task<IActionResult> Genre(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenre(genreId);

            if (!movies.Any())
            {
                return NotFound("We did not find any movies");
            }
            return Ok(movies);
        }

    }
}
