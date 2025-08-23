using HappyHouse_Server.DTO;
using HappyHouse_Server.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HappyHouse_Server.Controllers
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
