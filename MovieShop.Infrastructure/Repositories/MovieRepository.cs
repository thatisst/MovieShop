﻿using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;
using MovieShop.Core.Exceptions;
using MovieShop.Core.Helpers;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    { // EfRepository already implemented 8 methods of IMovieRepository (methods inherited from IAsyncRepository)
        //MovieRepository only need to implement the remaining 2 methods of IMovieRepository
        // and override any of the 8 methods in EfRepository

        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {    
            //return await _dbContext.Movies.OrderByDescending(m => m.Rating).Take(25).ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetTopRevenueMovies()
        {
            return await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(25).ToListAsync();
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) throw new NotFoundException("Movie Not Found");

            //var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
            //    .AverageAsync(r => r == null ? 0 : r.Rating);
            //if (movieRating > 0)
            //    movie.Rating = movieRating;

            return movie;
        }

        public async Task<IEnumerable<Review>> GetMovieReviews(int id)
        {// think about linq again, TODO
            var reviews = await _dbContext.Reviews.Where(r => r.MovieId == id).Include(r => r.User)
                .Select(r => new Review
                {
                    UserId = r.UserId,
                    MovieId = r.MovieId,
                    //Rating = r.Rating,
                    ReviewText = r.ReviewText,
                    User = new User
                    {
                        Id = r.UserId,
                        FirstName = r.User.FirstName,
                        LastName = r.User.LastName
                    }
                    
                }).Take(10).ToListAsync();
            return reviews;
        }

        public async Task<PaginatedList<Movie>> GetMovieByGenres(int genreId, int pageSize = 25, int page = 1)
        {// think about linq again, TODO
            var totalMoviesCountByGenre = await _dbContext.Genres.Include(g => g.Movies)
                .Where(g => g.Id == genreId).SelectMany(g => g.Movies).CountAsync();
            var movies = await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Id == genreId)
                .SelectMany(g => g.Movies).OrderByDescending(m => m.Revenue)
                .Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<Movie>(movies, totalMoviesCountByGenre, page, pageSize);
        }
    }
}
