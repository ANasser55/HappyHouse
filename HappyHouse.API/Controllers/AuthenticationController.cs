using HappyHouse.Application.DTOs;
using HappyHouse.Application.Interfaces;
using HappyHouse.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this._authService = authenticationService;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> AuthenticateUser(UserDTO userDTO)
        {
            var token = await _authService.AuthenticateUser(userDTO);

            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { message = "Invalid username or password" });

            return Ok(token);
        }
    }
}
