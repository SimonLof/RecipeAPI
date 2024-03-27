using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Interfaces
{
    public interface ITestRepo
    {
        Task<List<RecipeCategory>> GetRecipeCategories();
    }
}
