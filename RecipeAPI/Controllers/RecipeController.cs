using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Controllers
{
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
        [HttpPost("/api/recipe/add")]
        public async Task<IActionResult> CreateNewRecipe([FromBody] RecipeCreationDTO recipe)
        {
            if (recipe == null) return BadRequest("Invalid recipe.");

            return Ok(recipe);
        }
    }
}
