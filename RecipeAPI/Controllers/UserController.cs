using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Domain.DTO;
using System.Security.Claims;

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
            try
            {
                var userList = await _userService.GetUsers();
                return Ok(userList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("/api/{userID}")]
        public async Task<IActionResult> GetUserFromID(int userID)
        {
            try
            {
                var user = await _userService.GetUserById(userID);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize("appUser")]
        [HttpGet("/api/{userID}/delete")]
        public async Task<IActionResult> DeleteUser(int userID)
        {
            try
            {
                var loggedInID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (loggedInID == userID.ToString())
                {
                    await _userService.DeleteUser(userID);
                    return Ok("Your user has been deleted. Be aware that your current JWT might still work for up to 1 hour.");
                }
                else
                {
                    return BadRequest("You can only delete your own account.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("/api/register")]
        public async Task<IActionResult> NewUser([FromBody] UserDTO user)
        {
            try
            {
                await _userService.CreateUser(user);
                return StatusCode(201, user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
