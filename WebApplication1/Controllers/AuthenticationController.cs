using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using JourneyNavigation.Domain.Dtos;
using JourneyNavigation.Domain.Interfaces;
using JourneyNavigation.Domain.Models;

namespace JourneyNavigation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _userroleManager;

        public AuthenticationController(ILoginService loginService, UserManager<User> userManager, RoleManager<UserRole> userroleManager)
        {
            _loginService = loginService;
            _userManager = userManager;
            _userroleManager = userroleManager;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userLogin)
        {
            var user = await _loginService.Authenticate(userLogin);

            if (user != null)
            {
                var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

                var token = _loginService.Generate(user, isAdmin);
                return Ok(token);
            }

            return NotFound("User not found");
        }
        
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userForRegistration)
        {
            if (userForRegistration == null || !ModelState.IsValid)
                return BadRequest();

            var user = new User { UserName = userForRegistration.Username, Email = userForRegistration.Email };
            //var role = "user";

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            //var r = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                var error = result.Errors.FirstOrDefault().Description;

                throw new Exception(error);
            }

            return StatusCode(201);
        }

    }
}
