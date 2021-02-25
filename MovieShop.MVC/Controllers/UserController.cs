using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
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
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public UserController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        [HttpGet]
        //[Authorization] // filter
        public async Task<IActionResult> BuyMovie(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            return View(movie);
        }

        [HttpPost]
        //[Authorization] // filter
        public async Task<IActionResult> BuyMovie(PurchaseRequestModel purchaseRequestModel, string returnUrl=null)
        {
            returnUrl ??= Url.Content("~/");

            //// call UserService to save the movie that will call repository, which will save in Purchase Table
            var purchase = await _userService.PurchaseMovie(purchaseRequestModel);
            return LocalRedirect(returnUrl);
        }

        [HttpGet]
        public async Task<IActionResult> ReviewMovie(int id)
        {
            var movie = await _movieService.GetMovieById(id);

            return View(movie);
        }

        [HttpPost]
        public async Task<IActionResult> ReviewMovie(ReviewRequestModel reviewRequestModel, string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            var review = await _userService.PostMoviewReview(reviewRequestModel);
            return LocalRedirect(returnUrl);
        }
    }
}
