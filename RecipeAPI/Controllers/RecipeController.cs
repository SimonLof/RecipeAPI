using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Domain.DTO;
using System.Security.Claims;

namespace RecipeAPI.Controllers
{
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [AllowAnonymous]
        [HttpGet("/api/recipes")]
        public async Task<IActionResult> GetAllRecipe()
        {
            var recipes = await _recipeService.GetAllRecipes();

            return Ok(recipes);
        }

        [AllowAnonymous]
        [HttpGet("/api/recipe/{recipeID}")]
        public async Task<IActionResult> GetRecipe(int recipeID)
        {
            return Ok(await _recipeService.GetRecipe(recipeID));
        }

        [Authorize(Roles = "appUser")]
        [HttpPost("/api/recipe/add")]
        public async Task<IActionResult> CreateNewRecipe([FromBody] RecipeCreationDTO recipe)
        {
            if (recipe == null) return BadRequest("Invalid recipe.");
            try
            {
                var createdRecipe = await _recipeService.CreateRecipe(recipe, User.FindFirstValue(ClaimTypes.NameIdentifier));

                return Created("", createdRecipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
