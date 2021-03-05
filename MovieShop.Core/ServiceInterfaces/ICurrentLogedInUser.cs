using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface ICurrentLogedInUser
    {
        int? UserId { get; }
        string UserName { get; }
        string FullName { get; }
        string Email { get; }
        IEnumerable<string> Roles { get; }
        bool IsAdmin { get; }
        bool IsSuperAdmin { get; }
        bool IsAuthenticated { get; }
        string RemoteIpAddress { get; }
        IEnumerable<Claim> GetClaimsIdentity();
        public string ProfilePictureUrl { get; set; }

    }
}
