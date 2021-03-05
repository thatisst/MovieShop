using MovieShop.Core.Entities;
using MovieShop.Core.Helpers;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<MovieDetailsResponseModel> GetMovieById(int id);
        Task<MovieCardResponseModel> GetReviewsForMovie(int id);
        Task<PaginatedList<MovieCardResponseModel>> GetMoviesByGenre(int id, int pageSize = 25, int page = 1);
        Task<PagedResultSet<MovieResponseModel>> GetAllPurchasesByMovieId(int id);
        Task<PagedResultSet<MovieDetailsResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 1, string title = "");
        Task<PagedResultSet<MovieResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 1);

        Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequestModel movieCreateRequestModel);
        Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequestModel movieCreateRequestModel);

        Task<IEnumerable<MovieCardResponseModel>> GetTop25GrossingMovies();
        Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies();
        Task<int> GetMoviesCount(string title = "");




    }
}
