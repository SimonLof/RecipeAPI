using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RecipeAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [Authorize(Roles = "appUser")]
        [HttpGet("/test/get-my-claims")]
        public async Task<IActionResult> GetUserClaims()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            //return Ok(await Task.FromResult(new { userID, userRole })); Den här så klagar den inte på no await?
            return Ok(new { userID, userRole });
        }
    }
}
