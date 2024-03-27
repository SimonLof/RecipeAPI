using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("/api/users")]
        public IActionResult GetAllUser()
        {
            return Ok();
        }

        [HttpPost("/api/register")]
        public IActionResult NewUser([FromBody] UserDTO user)
        {
            _userService.CreateUser(user);
            return Ok();
        }
    }
}
