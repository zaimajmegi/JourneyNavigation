using TaskManagement.API.Dtos;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Infrastructure;
using TaskManagement.API.Extensions;
using TaskManagement.Infrastructure.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace TaskManagement.API.Services
{
    public class AuthenticationService : ILoginService
    {
        private IConfiguration _config;
        protected readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AuthenticationService(ApplicationDbContext context, IConfiguration config, UserManager<User> userManager)
        {
            _context = context;
            _config = config;
            _userManager = userManager;

        }


        public string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User> Authenticate(UserDto userLogin)
        {
            var currentUser = await _userManager.FindByNameAsync(userLogin.UserName);

            if (currentUser == null)
            {
                throw new Exception("User not found");
            }
            else if(!await _userManager.CheckPasswordAsync(currentUser, userLogin.Password))
            {
                throw new Exception("Password is incorrect");
            }
             
            return currentUser;
        }
    }
}
