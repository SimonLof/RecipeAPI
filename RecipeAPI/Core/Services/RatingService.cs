using RecipeAPI.Core.Interfaces;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.DTO;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Core.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepo _ratingRepo;

        public RatingService(IRatingRepo ratingRepo)
        {
            _ratingRepo = ratingRepo;
        }

        public async Task ChangeRating(RatingDTO ratingDTO)
        {
            throw new NotImplementedException();
        }

        public async Task GiveRating(RatingDTO ratingDTO)
        {
            var recipe = await _ratingRepo.GetRecipe(ratingDTO.RecipeID)
                ?? throw new Exception("No recipe with that ID.");

            var user = await _ratingRepo.GetApplicationUser(ratingDTO.UserID)
                ?? throw new Exception("No user with that ID.");

            if (recipe.User.UserID == user.UserID)
                throw new Exception("Cannot rate your own recipe.");

            var newRating = new Rating
            {
                FromUser = user,
                OnRecipe = recipe,
                Score = ratingDTO.Score,
            };

            await _ratingRepo.PostNewRating(newRating);
        }
    }
}
