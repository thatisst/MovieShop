using AutoMapper;
using MovieShop.Core.Entities;
using MovieShop.Core.Helpers;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {       
        private readonly IMovieRepository _movieRepository;
        private readonly IAsyncRepository<Review> _reviewRepository;

        //private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, 
            //IMapper mapper,
            IAsyncRepository<Review> reviewRepository)
        {
            _movieRepository = movieRepository;
            //_mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequestModel movieCreateRequestModel)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<MovieResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<MovieResponseModel>> GetAllPurchasesByMovieId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetHighestGrossingMovies()
        {           
            var movies = await _movieRepository.GetTopRevenueMovies();
            return movies;
        }

        public async Task<MovieDetailsResponseModel> GetMovieById(int id)
        {
            var movieDetails = new MovieDetailsResponseModel();
            var movie = await _movieRepository.GetByIdAsyc(id);
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

        public Task<PaginatedList<MovieResponseModel>> GetMoviesByGenre(int genreId, int pageSize = 25, int page = 1)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<MovieResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 1, string title = "")
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMoviesCount(string title = "")
        {
            throw new NotImplementedException();
        }

        public async Task<MovieCardResponseModel> GetReviewsForMovie(int id)
        {
            //Expression<Func<Review, bool>> filterExpression = review => review.MovieId == id;
            //var reviews = await _reviewRepository.GetPagedData(1, 25, rev => rev.OrderByDescending(r => r.Rating),
            //    filterExpression, review => review.Movie);

            //var response = _mapper.Map<IEnumerable<ReviewMovieResponseModel>>(reviews);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MovieCardResponseModel>> GetTop25GrossingMovies()
        {
            var movies = await _movieRepository.GetTopRevenueMovies();
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

        public async Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies()
        {
            var topMovies = await _movieRepository.GetTopRatedMovies();
            // map Movie to MovieResponseModel, TODO
            var response = new List<MovieResponseModel>();
            return response;
        }

        public Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequestModel movieCreateRequestModel)
        {
            throw new NotImplementedException();
        }
    }

  
}
