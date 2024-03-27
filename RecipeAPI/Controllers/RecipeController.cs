using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
