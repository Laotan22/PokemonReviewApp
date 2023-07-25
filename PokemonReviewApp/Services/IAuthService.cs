using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Services
{
    public interface IAuthService
    {
        public string CreateToken(User user);
        public User Register(UserDto request);
        public string Login(UserDto request);
        public bool ValidateUsername(UserDto request);
        public bool ValidatePassword(UserDto request);
    }
}
