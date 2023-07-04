using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TaskManagement.API.Dtos;
using TaskManagement.Domain.Dtos;
using TaskManagement.Domain.Interfaces;
using TaskManagement.Domain.Models;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly UserManager<User> _userManager;

        public AuthenticationController(ILoginService loginService, UserManager<User> userManager)
        {
            _loginService = loginService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userLogin)
        {
            var user = await _loginService.Authenticate(userLogin);

            if (user != null)
            {
                var token = _loginService.Generate(user);
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
            var role = "user";

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);
            var r = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                //return BadRequest(new RegistrationResponseDto { Errors = errors });
            }

            return StatusCode(201);
        }

        }
}
