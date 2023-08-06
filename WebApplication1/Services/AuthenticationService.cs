using JourneyNavigation.Domain.Dtos;
using JourneyNavigation.Domain.Interfaces;
using JourneyNavigation.API.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JourneyNavigation.Domain.Models;
using Microsoft.AspNetCore.Identity;
using JourneyNavigation.Infrastructure.Data;
using System.Data;

namespace JourneyNavigation.API.Services
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


        public string Generate(User user, bool isAdmin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserName));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            if (isAdmin) claims.Add(new Claim(ClaimTypes.Role, "Admin"));

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
