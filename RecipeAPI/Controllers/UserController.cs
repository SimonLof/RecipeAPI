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
        [HttpGet("/api/allusers")]
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
        [HttpGet("/api/user/{userID}")]
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


        [Authorize(Roles = "appUser")]
        [HttpDelete("/api/user/delete")]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                await _userService.DeleteUser(int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                return Ok("User deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "appUser")]
        [HttpPut("/api/user/update")]
        public async Task<IActionResult> UpdateUser([FromBody] UserDTO user)
        {
            try
            {
                var loggedInID = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (loggedInID == user.UserID.ToString())
                {
                    return Ok(await _userService.UpdateUser(user));
                }
                else
                {
                    return BadRequest("You can only update your own account.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [AllowAnonymous]
        [HttpPost("/api/user/register")]
        public async Task<IActionResult> NewUser([FromBody] UserDTO user)
        {
            try
            {
                var createdUser = await _userService.CreateUser(user);
                return StatusCode(201, createdUser);
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
