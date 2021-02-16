using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MovieShop.Core.RepositoryInterfaces
{
    //Generic Constraints !!
    public interface IAsyncRepository<T> where T : class
    {
        // CRUD
        // R - Reading
        T GetByIdAsyc(int id); //Get Genre by Id
        IEnumerable<T> ListAllAsync(); //Return all Genres

        // LINQ list of movies on some where condition (where m.title = "Aven", m.revenue > 1000000)
        IEnumerable<T> ListAsync(Expression<Func<T, bool>> filter);//Based on filters, give a list of Movies
        int GetCountAsync(Expression<Func<T, bool>> filter = null); // '=null' is default value
        bool GetExistAsync(Expression<Func<T, bool>> filter = null);

        // C - Create
        T AddAsync(T entity);

        // U - Update
        T UpdateAsync(T entity);

        // D - Delete
        T DeleteAsync(T entity);
    }
}
