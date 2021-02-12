using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetTopRevenueMovies();
        IEnumerable<Movie> GetHighestRatedMovies();
    }
}
