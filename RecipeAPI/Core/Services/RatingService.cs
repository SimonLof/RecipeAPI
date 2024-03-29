using AutoMapper;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.DTO;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Core.Services
{
    public class RatingService : IRatingService
    {
        private readonly IRatingRepo _ratingRepo;
        private readonly IMapper _mapper;

        public RatingService(IRatingRepo ratingRepo, IMapper mapper)
        {
            _ratingRepo = ratingRepo;
            _mapper = mapper;
        }

        public Task ChangeRating(RatingDTO ratingDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<RecipeViewDTO> GiveRating(RatingDTO ratingDTO)
        {
            var recipe = await _ratingRepo.GetRecipe(ratingDTO.RecipeID)
                ?? throw new Exception("No recipe with that ID.");

            var user = await _ratingRepo.GetApplicationUser(ratingDTO.UserID)
                ?? throw new Exception("No user with that ID.");

            if (recipe.User.UserID == user.UserID)
                throw new Exception("Cannot rate your own recipe.");

            if (recipe.Ratings.Any(r => r.FromUser.UserID == user.UserID))
                throw new Exception("Only one rating per recipe allowed.");

            var newRating = new Rating
            {
                FromUser = user,
                OnRecipe = recipe,
                Score = ratingDTO.Score,
            };

            return _mapper.Map<RecipeViewDTO>(await _ratingRepo.PostNewRating(newRating));
        }
    }
}
