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
            movieDetails.BackdropUrl = movie.BackdropUrl;
            movieDetails.RunTime = movie.RunTime;
            movieDetails.Price = movie.Price;
            movieDetails.Revenue = movie.Revenue;
            movieDetails.ImdbUrl = movie.ImdbUrl;
            movieDetails.TmdbUrl = movie.TmdbUrl;
            movieDetails.OriginalLanguage = movie.OriginalLanguage;
            movieDetails.Tagline = movie.Tagline;

            List<GenreModel> genreList = new List<GenreModel>();
            foreach (var genre in movie.Genres)
            {
                genreList.Add(new GenreModel { Id = genre.Id, Name = genre.Name });
            }
            movieDetails.Genres = genreList;

            List<CastResponseModel> movieCastList = new List<CastResponseModel>();
            foreach (var movieCast in movie.MovieCasts)
            {
                movieCastList.Add(new CastResponseModel
                {
                    Id = movieCast.CastId,
                    Name = movieCast.Cast.Name,
                    ProfilePath = movieCast.Cast.ProfilePath,
                    Character = movieCast.Character,
                    Gender = movieCast.Cast.Gender
                }); 
            }
            movieDetails.Casts = movieCastList;

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
