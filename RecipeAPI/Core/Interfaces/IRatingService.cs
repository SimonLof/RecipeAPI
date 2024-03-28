using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Core.Interfaces
{
    public interface IRatingService
    {
        Task<RecipeViewDTO> GiveRating(RatingDTO ratingDTO);
        Task ChangeRating(RatingDTO ratingDTO);
    }
}
