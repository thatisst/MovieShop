using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieShop.Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    { // EfRepository already implemented 8 methods of IMovieRepository (methods inherited from IAsyncRepository)
        //MovieRepository only need to implement the remaining 2 methods of IMovieRepository
        // and override any of the 8 methods in EfRepository

        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Movie> GetHighestRatedMovies()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetTopRevenueMovies()
        {
            return _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(20);
        }

        public override Movie GetByIdAsyc(int id)
        {
            return _dbContext.Movies.FirstOrDefault(m => m.Id == id);
            //return base.GetByIdAsyc(id);
        }
    }
}
