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

namespace TaskManagement.API.Services
{
    public class LoginService : ILoginService
    {
        private IConfiguration _config;
        protected readonly ApplicationDbContext _context;
        public LoginService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
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

        public User Authenticate(UserDto userLogin)
        {
            var currentUser = _context.Users.FirstOrDefault(o => o.UserName.ToLower() == userLogin.UserName.ToLower() && o.PasswordHash == userLogin.PasswordHash);

            if (currentUser != null)
            {
                return currentUser;
            }

            return null;
        }
    }
}
