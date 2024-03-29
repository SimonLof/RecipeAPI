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
            try
            {
                var recipes = await _recipeService.GetAllRecipes();

                return Ok(recipes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("/api/recipe/{recipeID}")]
        public async Task<IActionResult> GetRecipe(int recipeID)
        {
            try
            {
                return Ok(await _recipeService.GetRecipe(recipeID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("/api/recipe/search/{searchstring}")]
        public async Task<IActionResult> SearchRecipe(string searchstring)
        {
            try
            {
                return Ok(await _recipeService.SearchRecipe(searchstring));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [Authorize(Roles = "appUser")]
        [HttpPut("/api/recipe/{recipeID}/update")]
        public async Task<IActionResult> UpdateRecipe([FromBody] RecipeCreationDTO recipe, int recipeID)
        {
            try
            {
                if (recipe == null) return BadRequest("Invalid recipe");

                var userID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                return Ok(await _recipeService.UpdateRecipe(recipe, recipeID, userID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "appUser")]
        [HttpDelete("/api/recipe/{recipeID}/delete")]
        public async Task<IActionResult> DeleteRecipe(int recipeID)
        {
            try
            {
                var recipeName = await _recipeService.DeleteRecipe(recipeID, int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)));
                return Ok($"{recipeName} deleted!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
