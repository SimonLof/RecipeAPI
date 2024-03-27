using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Interfaces
{
    public interface IRatingRepo
    {
        Task<ApplicationUser> GetApplicationUser(int id);
        Task<Recipe> GetRecipe(int id);
        Task PostNewRating(Rating rating);
    }
}
