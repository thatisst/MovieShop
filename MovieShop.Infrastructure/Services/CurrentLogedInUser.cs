﻿using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace MovieShop.Infrastructure.Services
{
    public class CurrentLogedInUser : ICurrentLogedInUser
    {
        // HttpContext => it will give us all the information regarding that Http Request such as cookies, forms, method typr get/post
        // browsers, User, IsAuthenticated, Claims

        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentLogedInUser(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public bool IsAuthenticated => GetAuthenticated();
        private bool GetAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User.Identity != null 
                && _httpContextAccessor.HttpContext != null 
                &&  _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public string FullName => GetFullName();
        private string GetFullName()
        {
            var firstName = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.GivenName).Value;
            var lastName = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Surname).Value;

            return firstName + " " + lastName;
        }


        public string Email => _httpContextAccessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;


        public IEnumerable<string> Roles => GetRoles();
        private IEnumerable<String> GetRoles()
        {
            var claims = GetClaimsIdentity();
            var roles = new List<string>();
            foreach (var claim in claims)
            {
                if (claim.Type == ClaimTypes.Role)
                    roles.Add(claim.Value);
            }
            return roles;
        }


        public bool IsAdmin => GetIsAdmin();
        private bool GetIsAdmin()
        {
            var roles = Roles;
            return roles.Any(r => r.Contains("Admin"));
        }


        public bool IsSuperAdmin => GetIsSuperAdmin();
        private bool GetIsSuperAdmin()
        {
            var roles = Roles;
            return roles.Any(r => r.Contains("SuperAdmin"));
        }


        public int? UserId => GetUserId();
        private int? GetUserId()
        {
            // read from cookie - get User Id
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userId;
        }


        public string ProfilePictureUrl { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string UserName => _httpContextAccessor.HttpContext?.User.Identity?.Name;


        public string RemoteIpAddress => GetRemoteIpAddress();
        private string GetRemoteIpAddress()
        {
            return _httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString();
        }


        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _httpContextAccessor.HttpContext.User.Claims;
        }
    }
}
