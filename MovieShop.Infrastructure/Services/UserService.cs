using MovieShop.Core.Entities;
using MovieShop.Core.Exceptions;
using MovieShop.Core.Helpers;
using MovieShop.Core.Models.Request;
using MovieShop.Core.Models.Response;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace MovieShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IAsyncRepository<Review> _reviewRepository;
        private readonly ICryptoService _cryptoService;
        private readonly IMovieService _movieService;
        private readonly ICurrentLogedInUser _currentLogedInUser;

        public UserService(IUserRepository userRepository, ICryptoService cryptoService, 
            IPurchaseRepository purchaseRepository, IMovieService movieService,
            IAsyncRepository<Review> reviewRepository,
            ICurrentLogedInUser currentLogedInUser)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
            _purchaseRepository = purchaseRepository;
            _movieService = movieService;
            _reviewRepository = reviewRepository;
            _currentLogedInUser = currentLogedInUser;
        }

        public async Task<bool> PurchaseMovie(PurchaseRequestModel purchaseRequestModel)
        {
            // Check if user is authorized
            if (_currentLogedInUser.UserId != purchaseRequestModel.UserId)
                throw new HttpException(HttpStatusCode.Unauthorized, "You are not authorized to purchase.");
            //// Assign UserId 
            //if (_currentLogedInUser.UserId != 0)
            //    purchaseRequestModel.UserId = _currentLogedInUser.UserId;

            //Check if User has logged in
            if (purchaseRequestModel.UserId == 0)
                return false;

            //Get movie price from movie table
            var movie = await _movieService.GetMovieById(purchaseRequestModel.MovieId);
            purchaseRequestModel.TotalPrice = movie.Price;

            var purchase = new Purchase
            {
                UserId = purchaseRequestModel.UserId,
                PurchaseNumber = purchaseRequestModel.PurchaseNumber,
                TotalPrice = (decimal)purchaseRequestModel.TotalPrice,
                PurchaseDateTime = purchaseRequestModel.PurchaseDateTime,
                MovieId = purchaseRequestModel.MovieId
            };

            // save to database
            var createdPurchase = await _purchaseRepository.AddAsync(purchase);
            // check is save is successful
            if (createdPurchase != null || createdPurchase.Id > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> PostMoviewReview(ReviewRequestModel reviewRequestModel)
        {
            // return if (MovieId + UserId has been in the Review table)

            // Map submitted review to Review entity
            var review = new Review
            {
                UserId = reviewRequestModel.UserId,
                MovieId = reviewRequestModel.MovieId,
                Rating = reviewRequestModel.Rating,
                ReviewText = reviewRequestModel.ReviewText
            };

            // save to database
            var createdReview = await _reviewRepository.AddAsync(review);
            // check is save is successful
            if (createdReview != null || createdReview.Rating > 0)
            {
                return true;
            }

            return false;
        }


        public async Task<bool> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            // we need to check whether that email exists or not
            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);
            if (dbUser != null)
            {
                throw new ConflictException("Email already exists");
            }

            // first generate Salt
            var salt = _cryptoService.GenerateRandomSalt();
            var hashedPassword = _cryptoService.HashPassword(userRegisterRequestModel.Password, salt);
            // hash the password with salt and save the salt and hashed password to the Database


            var user = new User
            {
                Email = userRegisterRequestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                FirstName = userRegisterRequestModel.FirstName,
                LastName = userRegisterRequestModel.LastName,
                DateOfBirth = userRegisterRequestModel.DateOfBirth
            };

            var createdUser = await _userRepository.AddAsync(user);

            if (createdUser != null && createdUser.Id > 0)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseModel> ValidateUser(LoginRequestModel loginRequestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(loginRequestModel.Email);

            if (dbUser == null)
            {
                return null;
            }

            var hashedPassword = _cryptoService.HashPassword(loginRequestModel.Password, dbUser.Salt);

            //Get the roles of the user

            if (hashedPassword == dbUser.HashedPassword)
            {
                // User has entered correct password

                var loginResponse = new LoginResponseModel
                {
                    Id = dbUser.Id,
                    Email = dbUser.Email,
                    FirstName = dbUser.FirstName,
                    LastName = dbUser.LastName,
                    DateOfBirth = dbUser.DateOfBirth                 
                };

                var roles = new List<RoleModel>();
                foreach (var role in dbUser.Roles)
                {
                    roles.Add(new RoleModel {Name = role.Name, Id = role.Id});
                }
                loginResponse.Roles = roles;


                return loginResponse;
            }

            return null;

        }

        public Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultSet<User>> GetAllUsersByPagination(int pageSize = 20, int page = 0, string lastName = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequestModel)
        {
            throw new NotImplementedException();
        }

        public Task<PurchaseResponseModel> GetAllPurchaseForUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateMoviewReview(ReviewRequestModel reviewRequestModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteMoviewReview(int userId, int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<ReviewResponseModel> GetAllReviewsByUser(int userId, int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
