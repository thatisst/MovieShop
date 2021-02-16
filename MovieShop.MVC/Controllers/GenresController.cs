using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class GenresController : Controller
    {
        //private readonly MovieShopDbContext _dbContext;
        //public GenresController(MovieShopDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}
        public IActionResult Index()
        {
            //// Get all the list of geres from database
            //// Call our Genres Services that will cal Genres Repository that will 
            //// use EF to get the data

            ////using (var db = new MovieShopDbContext(new DbContextOptions<>(MovieShopDbContext)))
            ////{
            ////    var genres = _dbContext.Genres.ToList();
            ////    // select * from genres
            ////}

            ////var genres = _dbContext.Genres.ToList();
            ////// Genres is type DbSet
            //var genres = _dbContext.Genres.Where(g => g.Name.Contains("A")).ToList(); //return collection, out-memory
            //var genresFilter = _dbContext.Genres.ToList().Where(g => g.Name.Contains("A")).ToList(); //in-memory, bad for large data


            //var genresCount = _dbContext.Genres.Count(); // return integer
            //var genres2 = _dbContext.Genres.FirstOrDefault(g => g.Id == 2); // return single entity or null
            //var genres3 = _dbContext.Genres.First(g => g.Id == 200); // throw exception, use First() unless 100% sure the rows exist
            //var genresSingle = _dbContext.Genres.Single(g => g.Id == 200); // throw exception, use First() unless 100% sure the rows exist
            //var genresSingleOrDefault = _dbContext.Genres.SingleOrDefault(g => g.Id == 200); // throw exception, use First() unless 100% sure the rows exist
            
            ////Single and SingleOrDefault - Assignment
            ////Link LINQ to SQL
            //// SQL Profiler - shows any SQL statements running

            ////LINQ on IQueryable - work on out-memory objects
            //// Genres is type DbSet which inherits IQueryable, which contains the following extension method
            ////public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate);

            //// LINQ on IEnumerable - work on in-memory objects
            ////public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, Func<TSource, bool> predicate);


            return View();
        }
    }
}
