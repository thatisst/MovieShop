using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MovieShop.Core.Entities;
using MovieShop.Core.Helpers;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MovieShop.UnitTest
{
    [TestClass]
    public class MovieServiceUnitTest
    {

        private MovieService _sut;
        private static List<Movie> _movies;
        private static int _count;
        Expression<Func<Movie, bool>> filter = null;
        private Mock<IMovieRepository> _mockMovieRepository;
        private Mock<IPurchaseRepository> _mockPurchaseRepository;
        private Mock<IAsyncRepository<Review>> _mockReviewRepository;
        private Mock<IAsyncRepository<Favorite>> _mockFavoriteRepository;
        readonly IMapper _mapper;

        [TestInitialize]
        public void OneTimeSetup()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
            _mockPurchaseRepository = new Mock<IPurchaseRepository>();
            _mockReviewRepository = new Mock<IAsyncRepository<Review>>();
            _mockFavoriteRepository = new Mock<IAsyncRepository<Favorite>>();
            _mockMovieRepository.Setup(m => m.GetTopRevenueMovies()).ReturnsAsync(_movies);
            _mockMovieRepository.Setup(m => m.GetCountAsync(filter)).ReturnsAsync(_count);

            _sut = new MovieService(_mockMovieRepository.Object, _mapper, _mockReviewRepository.Object,
                _mockFavoriteRepository.Object, _mockPurchaseRepository.Object);
        }

        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            _movies = new List<Movie>
            {
                new Movie {Id = 1, Title = "Avengers", Budget = 12000000},
                new Movie {Id = 2, Title = "Frozen", Budget = 12000000}
            };
        }

        [TestMethod]
        public async Task TestListOfTopMoviesFromFakeData()
        {

            /*
             * AAA
             * Arrange
             * Act
             * Assert
             * 
             */

            //// test all methods in MovieService class
            //// SUT - System Under Test, e.g., MovieService
            //// Arrange
            //// mock objects, data, methods etc
            //_sut = new MovieService(new MockMovieRepository());

            // Act
            var movies = await _sut.GetTop25GrossingMovies();

            //check the actual output with expected data.
            // Assert
            Assert.IsNotNull(movies);
            
        }

        [TestMethod]
        public async Task TestGetMoviesCountFromFakeData()
        {
            var count = await _sut.GetMoviesCount();
            Assert.AreEqual(2, count);
        }

        //public class MockMovieRepository : IMovieRepository
        //{
        //    public Task<Movie> AddAsync(Movie entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<Movie> DeleteAsync(Movie entity)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<Movie> GetByIdAsync(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<int> GetCountAsync(Expression<Func<Movie, bool>> filter = null)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<bool> GetExistAsync(Expression<Func<Movie, bool>> filter = null)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<PaginatedList<Movie>> GetMovieByGenres(int genreId, int pageSize = 25, int page = 1)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<IEnumerable<Review>> GetMovieReviews(int id)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<PaginatedList<Movie>> GetPagedData(int pageIndex, int pageSize, Func<IQueryable<Movie>, IOrderedQueryable<Movie>> orderedQuery = null, Expression<Func<Movie, bool>> filter = null, params Expression<Func<Movie, object>>[] includes)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<IEnumerable<Movie>> GetTopRatedMovies()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public async Task<IEnumerable<Movie>> GetTopRevenueMovies()
        //    {
        //        // this method will get the fake data
        //        //throw new NotImplementedException();
        //        var _movies = new List<Movie>
        //        {
        //            new Movie {Id = 1, Title = "Avengers", Budget = 12000000},
        //            new Movie {Id = 2, Title = "Frozen", Budget = 12000000},
        //            new Movie {Id = 3, Title = "Star Wars", Budget = 12000000},
        //            new Movie {Id = 4, Title = "Fight Club", Budget = 12000000},
        //            new Movie {Id = 5, Title = "The Dark Knight", Budget = 12000000},
        //            new Movie {Id = 6, Title = "Toy City", Budget = 12000000},
        //            new Movie {Id = 7, Title = "Minions", Budget = 12000000},
        //            new Movie {Id = 8, Title = "Interstellar", Budget = 12000000}
        //        };

        //        return _movies;
        //    }

        //    public Task<IEnumerable<Movie>> ListAllAsync()
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<IEnumerable<Movie>> ListAllWithIncludeAsync(Expression<Func<Movie, bool>> where, params Expression<Func<Movie, object>>[] includes)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<IEnumerable<Movie>> ListAsync(Expression<Func<Movie, bool>> filter)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public Task<Movie> UpdateAsync(Movie entity)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}
