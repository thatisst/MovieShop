using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Helpers;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext;
        public EfRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync(); // !!!
            return entity;
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync(); // !!!
            return entity;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<T>().Where(filter).CountAsync();
            }
            return await _dbContext.Set<T>().CountAsync();
        }

        public virtual async Task<bool> GetExistAsync(Expression<Func<T, bool>> filter = null)
        {
            if (filter != null)
            {
                return await _dbContext.Set<T>().Where(filter).AnyAsync();
            }
            return await _dbContext.Set<T>().AnyAsync();
        }

        public async Task<PaginatedList<T>> GetPagedData(int pageIndex = 1, int pageSize = 25, 
            Func<IQueryable<T>, IOrderedQueryable<T>> orderedQuery = null, 
            Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            var pagedList =
                await PaginatedList<T>.GetPaged(_dbContext.Set<T>(), pageIndex, pageSize,
                orderedQuery, filter, includes);
            return pagedList;
        }

        public virtual async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAllWithIncludeAsync(Expression<Func<T, bool>> where, 
            params Expression<Func<T, object>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();
            if (includes != null)
            {
                foreach (Expression<Func<T, object>> navigationProperty in includes)
                {
                    query = query.Include(navigationProperty);
                }
            }
            return await query.Where(@where).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter)
        {
            var filteredList = await _dbContext.Set<T>().Where(filter).ToListAsync();
            return filteredList;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync(); // !!!
            return entity;
        }
    }
}
