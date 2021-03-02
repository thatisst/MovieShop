using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Models.Request
{
    public class UserProfileRequestModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ProfilePictureUrl { get; set; }
    }
}
