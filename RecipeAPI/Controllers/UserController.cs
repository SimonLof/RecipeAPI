using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "appUser")]
        [HttpGet("/api/users")]
        public async Task<IActionResult> GetAllUser()
        {
            var userList = await _userService.GetUsers();
            return Ok(userList);
        }

        [AllowAnonymous]
        [HttpPost("/api/register")]
        public async Task<IActionResult> NewUser([FromBody] UserDTO user)
        {
            await _userService.CreateUser(user);
            return StatusCode(201, user);
        }

        [AllowAnonymous]
        [HttpPost("/api/login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO user)
        {
            try
            {
                return Ok(await _userService.Login(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
