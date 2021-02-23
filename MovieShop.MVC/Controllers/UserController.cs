using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        // call this method when user clicks on Buy Movie on Movie Details page
        // for authenticated users only

        [HttpGet]
        //[Authorization] // filter
        public IActionResult BuyMovie()
        {
            // call UserService to save the movie that will call repository, which will save in Purchase Table
            return View();
        }
    }
}
