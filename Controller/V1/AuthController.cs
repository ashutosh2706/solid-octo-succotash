using Microsoft.AspNetCore.Mvc;
using MyApi.Data.Service;
using MyApi.Util;

namespace MyApi.Controller.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string username, [FromForm] string pass)
        {
            var user = await _userService.GetUser(username);
            if (user == null)
            {
                return NotFound();
            }
            if (user.Password != pass)
            {
                return Unauthorized("Password was incorrect");
            }

            var token = new AuthConfig(_configuration).GetToken(user);
            return Ok(token);
        }
    }
}