using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;
using PokemonReviewApp.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public static User user = new User();
        private readonly IAuthService _authService;

        //private readonly IConfiguration _configuration;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            User user = _authService.Register(request);
            
            return Ok(user);

            //string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            //user.Username = request.Username;
            //user.PasswordHash = passwordHash;
        }



        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto request)
        {
            string token = _authService.Login(request);

            if (string.IsNullOrEmpty(token)) 
            { 
                return BadRequest("Username or password is incorrect");  
            }
            
            return Ok(token);

            //if (user.Username != request.Username)
            //{
            //    return BadRequest("username or password is incorrect");
            //}

            //if(!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            //{
            //    return BadRequest("username or password is incorrect.");
            //}
        }
    }
}
