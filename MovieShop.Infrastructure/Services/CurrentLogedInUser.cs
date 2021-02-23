using Microsoft.AspNetCore.Http;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Claims;

namespace MovieShop.Infrastructure.Services
{
    class CurrentLogedInUser : ICurrentLogedInUser
    {
        // HttpContextt => give all the information regarding that Http Request
        // such as cookies, forms, method type GET/POST, browser, User, IsAuthenticated, Claims
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentLogedInUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool IsAuthenticated => GetAuthenticated();
        private bool GetAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User.Identity != null &&
                _httpContextAccessor.HttpContext != null &&
                _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }


        public string FullName => GetFullName();

        private string GetFullName()
        {
            var firstName = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName);
            var lastName = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname);
            return firstName + " " + lastName;
        }

        public string Email => throw new NotImplementedException();

        public List<string> Roles => throw new NotImplementedException();

        public bool IsAdmin => throw new NotImplementedException();

        public bool IsSuperAdmin => throw new NotImplementedException();

        public int UserId => throw new NotImplementedException();
    }
}
