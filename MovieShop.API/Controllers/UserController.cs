using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using Microsoft.AspNetCore.Authorization;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentLogedInUser _currentUser;

        public UserController(IUserService userService, IUserRepository userRepository,
            ICurrentLogedInUser currentUser)
        {
            _userService = userService;
            _userRepository = userRepository;
            _currentUser = currentUser;
        }

        //test-only method
        [Authorize]
        [HttpGet("{id:int}/purchases")]
        public async Task<ActionResult> GetUserPurchasedMoviesAsync(int id)
        {
            // we have to check the id from the url is equal to the id from the JWT TOken then only show the data
            if (id != _currentUser.UserId.Value)
            {
                return Unauthorized("Hey you cannot access other person's info!");
            }
            
            return Ok();
            //var userMovies = await _userService.GetAllPurchasesForUser(id);
            //return Ok(userMovies);
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> Purchase(PurchaseRequestModel purchaseRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check purchase");
            }

            var purchased = await _userService.PurchaseMovie(purchaseRequestModel);
            return Ok(purchased);
        }

        [HttpGet]
        [Route("{id}/purchase")]
        public async Task<IActionResult> GetPurchasesByUser(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check reviews by id");
            }

            var purchasedByUser = await _userService.GetAllPurchaseForUser(userId);
            return Ok(purchasedByUser);
        }

        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> Review(ReviewRequestModel reviewRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check review");
            }

            var reviewed = await _userService.PostMoviewReview(reviewRequestModel);
            return Ok(reviewed);
        }

        [HttpGet]
        [Route("{id}/reviews")]
        public async Task<IActionResult> GetReviewsByUser(int userId, int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check reviews by id");
            }

            var reviewedByUser = await _userService.GetAllReviewsByUser(userId, movieId);
            return Ok(reviewedByUser);
        }

        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateReview(ReviewRequestModel reviewRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check updated review");
            }

            var reviewUpdateded = await _userService.UpdateMoviewReview(reviewRequestModel);
            return Ok(reviewUpdateded);
        }

        [HttpDelete]
        [Route("{userId}/movie/{movieId}")]
        public async Task<IActionResult> DeleteReview(int userId, int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check deletion");
            }

            var reviewDeleted = await _userService.DeleteMoviewReview(userId, movieId);
            return Ok(reviewDeleted);
        }
    }
}
