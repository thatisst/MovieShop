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
        [Route("{id:int}")] 
        public async Task<IActionResult> GetMovieByIdAsync(int id)
        {
            var movie = await _movieService.GetMovieById(id);
            if (movie == null) return NotFound("No movies found!");
            return Ok(movie);
        }

        [HttpGet]
        [Route("")] 
        public async Task<IActionResult> GetAllMoviesAsync([FromQuery] int pageSize = 25, [FromQuery] int page = 1,
            string title = "")
        {
            var movies = await _movieService.GetMoviesByPagination(pageSize, page, title);
            if (movies == null) return NotFound("No movies found!");
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}/reviews")] 
        public async Task<IActionResult> GetReviewsByMovieAsync(int id)
        {
            var movie = await _movieRepository.GetMovieReviews(id);
            return Ok(movie);
        }

        [HttpGet]
        [Route("toprevenue")] // attribute based routing
        public async Task<IActionResult> GetTopRevenueMoviesAsync()
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
        public async Task<IActionResult> GetTopRatedMoviesAsync()
        {
            var movies = await _movieService.GetTopRatedMovies();

            if (!movies.Any())
            {
                return NotFound("We did not find any movies");
            }
            return Ok(movies);
        }

        [HttpGet]
        [Route("genre/{genreId:int}")] // attribute based routing
        public async Task<IActionResult> GetMoviesByGenreAsync(int genreId)
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
