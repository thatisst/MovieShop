using AutoMapper;
using MovieShop.Core.Entities;
using MovieShop.Core.Helpers;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {       
        private readonly IMovieRepository _movieRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IAsyncRepository<Review> _reviewRepository;
        private readonly IAsyncRepository<Favorite> _favoriteRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository,
            IMapper mapper,
            IAsyncRepository<Review> reviewRepository,
            IAsyncRepository<Favorite> favoriteRepository,
             IPurchaseRepository purchaseRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _reviewRepository = reviewRepository;
            _favoriteRepository = favoriteRepository;
            _purchaseRepository = purchaseRepository;
        }

        public Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequestModel movieCreateRequestModel)
        {
            // //if (_currentUserService.UserId != favoriteRequest.UserId)
            // //    throw new HttpException(HttpStatusCode.Unauthorized, "You are not Authorized to purchase");

            // // check whether the user is Admin and can create the movie claim

            // var movie = _mapper.Map<Movie>(movieCreateRequest);

            // var createdMovie = await _movieRepository.AddAsync(movie);
            //// var movieGenres = new List<MovieGenre>();
            // foreach (var genre in movieCreateRequest.Genres)
            // {
            //     var movieGenre = new MovieGenre {MovieId = createdMovie.Id, GenreId = genre.Id};
            //     await _genresRepository.AddAsync(movieGenre);
            // }

            // return _mapper.Map<MovieDetailsResponseModel>(createdMovie);
            throw new NotImplementedException();
        }

        public async Task<PagedResultSet<MovieResponseModel>> GetAllMoviePurchasesByPagination
            (int pageSize = 50, int page = 0)
        {
            var totalPurchases = await _purchaseRepository.GetCountAsync();
            var purchases = await _purchaseRepository.GetAllPurchases(pageSize, page);
            var data = _mapper.Map<List<MovieResponseModel>>(purchases);
            var purchasedMovies = new PagedResultSet<MovieResponseModel>(data, page, pageSize, totalPurchases);
            return purchasedMovies;
        }

        public Task<PagedResultSet<MovieResponseModel>> GetAllPurchasesByMovieId(int id)
        {
            throw new NotImplementedException();
        }

       
        public async Task<MovieDetailsResponseModel> GetMovieById(int id)
        {
            var movieDetails = new MovieDetailsResponseModel();
            var movie = await _movieRepository.GetByIdAsync(id);
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

        public async Task<PaginatedList<MovieCardResponseModel>> GetMoviesByGenre(int id, int pageSize = 25, int page = 1)
        {
            var pagedMovies = await _movieRepository.GetMovieByGenres(id, pageSize, page);
            ////map Movie to PaginatedList<MovieResponseModel>
            //var data = _mapper.Map<PaginatedList<MovieDetailsResponseModel>>(pagedMovies);

            List<MovieCardResponseModel> data = new List<MovieCardResponseModel>();
            foreach (var movie in pagedMovies)
            {
                data.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    Title = movie.Title,
                    Revenue = movie.Revenue
                });
            }

            var movies = new PaginatedList<MovieCardResponseModel>(data, pagedMovies.TotalCount, page, pageSize);
            return movies;
        }

        public async Task<PagedResultSet<MovieDetailsResponseModel>> GetMoviesByPagination(
            int pageSize = 20, int page = 1, string title = "")
        { 
            Expression<Func<Movie, bool>> filterExpression = null;
            if (!string.IsNullOrEmpty(title))
                filterExpression = movie => title != null && movie.Title.Contains(title);
            var pagedMovies = await _movieRepository.GetPagedData(
                page, pageSize, mov => mov.OrderBy(m => m.Title), filterExpression);
            var movies = new  PagedResultSet<MovieDetailsResponseModel>(_mapper.Map<List<MovieDetailsResponseModel>>(pagedMovies)
                , pagedMovies.PageIndex, pageSize, pagedMovies.TotalCount);
            return movies;
        }

        public async Task<int> GetMoviesCount(string title = "")
        {
            if (string.IsNullOrEmpty(title))
                return await _movieRepository.GetCountAsync();
            return await _movieRepository.GetCountAsync(m => m.Title.Contains(title));
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
            foreach (var movie in topMovies)
            {
                response.Add(new MovieResponseModel
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate

                });
            }
            return response;
        }

        public Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequestModel movieCreateRequestModel)
        {
            //var movie = _mapper.Map<Movie>(movieCreateRequest);

            //var createdMovie = await _movieRepository.UpdateAsync(movie);
            //// var movieGenres = new List<MovieGenre>();
            //foreach (var genre in movieCreateRequest.Genres)
            //{
            //    var movieGenre = new MovieGenre { MovieId = createdMovie.Id, GenreId = genre.Id };
            //    await _genresRepository.UpdateAsync(movieGenre);
            //}

            //return _mapper.Map<MovieDetailsResponseModel>(createdMovie);
            throw new NotImplementedException();
        }
    }

  
}
