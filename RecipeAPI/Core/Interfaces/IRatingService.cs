using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Core.Interfaces
{
    public interface IRatingService
    {
        Task GiveRating(RatingDTO ratingDTO);
        Task ChangeRating(RatingDTO ratingDTO);
    }
}
