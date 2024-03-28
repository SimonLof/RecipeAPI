using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Core.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeViewDTO> CreateRecipe(RecipeCreationDTO recipe, string userID);
        Task<List<RecipeViewDTO>> GetAllRecipes();
        Task<RecipeViewDTO> GetRecipe(int id);
    }
}
