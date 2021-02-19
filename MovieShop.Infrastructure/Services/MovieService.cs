using MovieShop.Core.Entities;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {       
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IEnumerable<Movie> GetHighestGrossingMovies()
        {
            
            var movies = _movieRepository.GetTopRevenueMovies();
            return movies;
        }

        public MovieDetailsResponseModel GetMovieById(int id)
        {
            var movieDetails = new MovieDetailsResponseModel();
            var movie = _movieRepository.GetByIdAsyc(id);
            //map movie entity to MovieDetailsResponseModel
            movieDetails.Id = movie.Id;
            movieDetails.Title = movie.Title;
            movieDetails.Overview = movie.Overview;
            movieDetails.Budget = movie.Budget;
            movieDetails.ReleaseDate = movie.ReleaseDate;
            movieDetails.PosterUrl = movie.PosterUrl;
            movieDetails.RunTime = movie.RunTime;
            movieDetails.Price = movie.Price;
            movieDetails.Revenue = movie.Revenue;
            movieDetails.ImdbUrl = movie.ImdbUrl;
            movieDetails.TmdbUrl = movie.TmdbUrl;
            movieDetails.OriginalLanguage = movie.OriginalLanguage;
            movieDetails.Tagline = movie.Tagline;
            //movieDetails.Genres = movie.Genres;
            //movieDetails.Casts = movie.MovieCasts; //movie.MovieCasts return null


            return movieDetails;
        }

        public IEnumerable<MovieCardResponseModel> GetTop25GrossingMovies()
        {
            var movies = _movieRepository.GetTopRevenueMovies();
            var movieResponseModel = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                var movieCard = new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl,
                    Revenue = movie.Revenue
                };
                movieResponseModel.Add(movieCard);
            }
            return movieResponseModel;
        }

        
    }

  
}
