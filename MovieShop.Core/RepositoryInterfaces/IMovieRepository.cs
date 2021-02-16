﻿using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {// 10 methods in total
        //2 mothods in addition to 8 methods in IAsyncRepository
        IEnumerable<Movie> GetTopRevenueMovies();
        IEnumerable<Movie> GetHighestRatedMovies();
    }
}
