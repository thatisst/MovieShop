using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {

        //get user by email
        Task<User> GetUserByEmail(string email);

    }
}
