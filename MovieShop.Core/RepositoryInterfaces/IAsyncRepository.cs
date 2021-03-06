﻿using MovieShop.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.RepositoryInterfaces
{
    //Generic Constraints !!
    public interface IAsyncRepository<T> where T : class
    {
        // CRUD
        // R - Reading
        Task<T> GetByIdAsync(int id); //Get Genre by Id
        Task<IEnumerable<T>> ListAllAsync(); //Return all Genres
        Task<IEnumerable<T>> ListAllWithIncludeAsync(Expression<Func<T, bool>> where,
            params Expression<Func<T, object>>[] includes); //Return all Genres


        // LINQ list of movies on some where condition (where m.title = "Aven", m.revenue > 1000000)
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);//Based on filters, give a list of Movies
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null); // '=null' is default value
        Task<bool> GetExistAsync(Expression<Func<T, bool>> filter = null);

        // C - Create
        Task<T> AddAsync(T entity);

        // U - Update
        Task<T> UpdateAsync(T entity);

        // D - Delete
        Task<T> DeleteAsync(T entity);

        Task<PaginatedList<T>> GetPagedData(int pageIndex, int pageSize,
           Func<IQueryable<T>, IOrderedQueryable<T>> orderedQuery = null,
           Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
    }
}
