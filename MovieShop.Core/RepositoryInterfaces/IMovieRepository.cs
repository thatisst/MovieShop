﻿using MovieShop.Core.Entities;
using MovieShop.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {// 10 methods in total
        //2 mothods in addition to 8 methods in IAsyncRepository
        Task<IEnumerable<Movie>> GetTopRevenueMovies();
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Review>> GetMovieReviews(int id);

        Task<PaginatedList<Movie>> GetMovieByGenres(int genreId, int pageSize = 25, int page = 1);

    }
}
