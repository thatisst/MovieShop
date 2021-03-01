using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.Models.Request;
using MovieShop.Core.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;
        public AccountController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpGet]
        public async Task<IActionResult> RegisterUser()
        {
       
           
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var user = await _userService.GetUser(email);

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please check data");
            }

            var registerUser = await _userService.RegisterUser(userRegisterRequestModel);
            return Ok(registerUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Login Failed");
            }

            var logedInUser = await _userService.ValidateUser(loginRequestModel);

            var tokenObject = new { token = _jwtService.GenerateJWT(logedInUser) };

            return Ok(tokenObject);
        }
    }
}
