using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Core.Interfaces;
using System.Security.Claims;

namespace RecipeAPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        [Authorize(Roles = "appUser")]
        [HttpGet("/test/categories")]
        public async Task<IActionResult> GetAllCategories()
        {
            return Ok(await _testService.GetAllRecipeCategories());
        }

        [Authorize(Roles = "appUser")]
        [HttpGet("/test/get-my-claims")]
        public IActionResult GetUserClaims()
        {
            var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            return Ok(new { userID, userRole });
        }
    }
}
