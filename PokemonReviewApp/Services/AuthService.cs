using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PokemonReviewApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public static User user = new User();

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
            new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Token").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public string Login(UserDto request)
        {
            if (!ValidateUsername(request))
            {
                throw new ArgumentException("Invalid Username or Password", nameof(request));
                //return null;
            }

            if (!ValidatePassword(request))
            {
                throw new ArgumentException("Invalid Username or Password", nameof(request));
            }

            string token = CreateToken(user);
            return token;
        }

        public bool ValidateUsername(UserDto request)
        {
            if (string.IsNullOrEmpty(request.Username))
                return false;

            if (user.Username != request.Username.Trim().ToLower())
                return false;

            return true;
        }

        public bool ValidatePassword(UserDto request) 
        {
            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
               return false;
            }
            return true;
        }

        public User Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.Username = request.Username.ToLower().Trim();
            user.PasswordHash = passwordHash;

            return user;
        }
    }
}
