using MovieShop.Core.Entities;
using MovieShop.Core.Helpers;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> RegisterUser(UserRegisterRequestModel userRegisterRequestModel);
        Task<LoginResponseModel> ValidateUser(string email, string password);
        Task<UserRegisterResponseModel> GetUserDetails(int id);
        Task<User> GetUser(string email);
        Task<PagedResultSet<User>> GetAllUsersByPagination(int pageSize = 20, int page = 0, string lastName = "");

        
        Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequestModel);
        Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequestModel);
        Task<PurchaseResponseModel> GetAllPurchaseForUser(int id);

        Task AddFavorite(FavoriteRequestModel favoriteRequestModel);
        Task RemoveFavorite(FavoriteRequestModel favoriteRequestModel);
        Task<bool> FavoriteExists(int id, int movieId);
        Task<FavoriteResponseModel> GetAllFavoritesForUser(int id);


        Task<bool> PostMoviewReview(ReviewRequestModel reviewRequestModel);
        Task<bool> UpdateMoviewReview(ReviewRequestModel reviewRequestModel);
        Task<bool> DeleteMoviewReview(int userId, int movieId);
        Task<ReviewResponseModel> GetAllReviewsByUser(int userId, int movieId);

        Task<Uri> UploadUserProfilePicture(UserProfileRequestModel userProfileRequestModel);



    }
}
