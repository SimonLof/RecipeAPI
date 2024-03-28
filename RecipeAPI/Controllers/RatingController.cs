using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using RecipeAPI.Core.Interfaces;
using RecipeAPI.Domain.DTO;

using System.Security.Claims;

namespace RecipeAPI.Controllers
{
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [Authorize(Roles = "appUser")]
        [HttpPost("/api/recipe/{recipeID}/rate/{rating}")]
        public async Task<IActionResult> GiveRating(int rating, int recipeID)
        {
            if (rating > 5 || rating < 1) return BadRequest("Rating is a score between 1-5");

            var newRating = new RatingDTO
            {
                RecipeID = recipeID,
                Score = rating,
                UserID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            };
            try
            {

                var newRecipe = await _ratingService.GiveRating(newRating);
                return Created($"/api/recipe/" + newRecipe.RecipeID, newRecipe);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
