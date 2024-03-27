using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Core.Interfaces
{
    public interface ITestService
    {
        Task<List<RecipeCategory>> GetAllRecipeCategories();
    }
}
