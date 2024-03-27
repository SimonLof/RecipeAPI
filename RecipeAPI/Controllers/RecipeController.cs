using Microsoft.AspNetCore.Mvc;

namespace RecipeAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllRecipe()
        {
            return Ok();
        }
    }
}
