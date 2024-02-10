using Microsoft.AspNetCore.Mvc;
using MyApi.Data.Service;
using MyApi.Data.Model;

namespace MyApi.Controller.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/v{version:apiVersion}/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            await _userService.Add(user);
            return Created("api/user", new
            {
                code = 201,
                message = "User Added"
            });
        }
    }
}