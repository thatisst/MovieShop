using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        /*
         * Dependency Injection can be done in 3 ways
         * 1. Constructor Injection
         * 2. Method Injection
         * 3. Property Injection 
         * */

        //cannot compile
        //MovieService movieservice = new MovieService()
        //can compile in other classes
        //MovieService movieservice = new MovieService(new MovieRepository())

        private readonly IMovieRepository _movieRepository;//cannot change after initialization
        private readonly int x; // readonly - Do not wish anyone to give a new type to 
        public MovieService(IMovieRepository movieRepository)
        {// this construction replace the default construction
            //constructor injection
            _movieRepository = movieRepository;
            x = 10; // only in constructor
        }
        public IEnumerable<Movie> GetHighestGrossingMovies()
        {
            
            var movies = _movieRepository.GetTopRevenueMovies();
            return movies;
        }

        //// IMovieRepository interface
        //// should depend on Interface, not a concrete class
        ////MovieRepository repo = new MovieRepository(); EF
        ////MovieRepository2 repo2 = new MovieRepository2(); Dapper
        //public List<Movie> GetTopRevenueMovies()
        //{
        //    //talk with database through Repository and get me top 20 movies
        //    //talking to repository
        //    // var movies = repo.GetMovies();
        //    return new List<Movie>();
        //}
    }

  
}
