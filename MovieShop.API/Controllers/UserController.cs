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

        [Authorize]
        [HttpPost("purchase")]
        public async Task<IActionResult> CreatePurchaseAsync([FromBody] PurchaseRequestModel purchaseRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check purchase");
            }

            var purchased = await _userService.PurchaseMovie(purchaseRequestModel);
            return Ok(purchased);
        }

        [Authorize]
        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> CreateFavoriteAsync([FromBody] FavoriteRequestModel favoriteRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check favorite");
            }

            await _userService.AddFavorite(favoriteRequestModel);
            return Ok();
        }

        [Authorize]
        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> RemoveFavoriteAsync([FromBody] FavoriteRequestModel favoriteRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check favorite");
            }

            await _userService.RemoveFavorite(favoriteRequestModel);
            return Ok();
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/movie/{movieId}/favorite")]
        public async Task<IActionResult> IsFavoriteExistAsync(int id, int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please log in to check if favorite exists");
            }

            var favoriteExists = await _userService.FavoriteExists(id, movieId);
            return Ok(new {isFavorited = favoriteExists});
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/purchase")]
        public async Task<IActionResult> GetPurchasedMoviesByUserAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check reviews by id");
            }

            if (id != _currentUser.UserId.Value)
                return Unauthorized("Hey you cannot access other person's info!");

            var purchasedByUser = await _userService.GetAllPurchaseForUser(id);
            return Ok(purchasedByUser);
        }

        
        [Authorize]
        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetReviewsByUserAsync(int userId, int movieId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check reviews by id");
            }

            var reviewedByUser = await _userService.GetAllReviewsByUser(userId, movieId);
            return Ok(reviewedByUser);
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}/favorites")]
        public async Task<IActionResult> GetFavoritesByUserAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check reviews by id");
            }

            var reviewedByUser = await _userService.GetAllFavoritesForUser(id);
            return Ok(reviewedByUser);
        }

        [Authorize]
        [HttpPost]
        [Route("review")]
        public async Task<IActionResult> CreateReviewAsync(ReviewRequestModel reviewRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check review");
            }

            var reviewed = await _userService.PostMoviewReview(reviewRequestModel);
            return Ok(reviewed);
        }

        [Authorize]
        [HttpPut]
        [Route("review")]
        public async Task<IActionResult> UpdateReviewAsync(ReviewRequestModel reviewRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check updated review");
            }

            var reviewUpdateded = await _userService.UpdateMoviewReview(reviewRequestModel);
            return Ok(reviewUpdateded);
        }

        [Authorize]
        [HttpDelete]
        [Route("{userId:int}/movie/{movieId:int}")]
        public async Task<IActionResult> DeleteReviewAsync(int userId, int movieId)
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
