using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllRecipe()
        {
            return Ok("All the recipes");
        }

        [Authorize(Roles = "appUser")]
        [HttpPost]
        public async Task<IActionResult> CreateNewRecipe([FromBody] Recipe recipe)
        {
            if (recipe == null) return BadRequest("Invalid recipe.");

            return Ok();
        }
    }
}
