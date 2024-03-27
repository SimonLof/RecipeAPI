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
        [HttpPost]
        public async Task<IActionResult> GiveRating(int rating, int recipeID)
        {
            var newRating = new RatingDTO
            {
                RecipeID = recipeID,
                Score = rating,
                UserID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier))
            };

            await _ratingService.GiveRating(newRating);
            return Created();
        }
    }
}
