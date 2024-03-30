using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Interfaces
{
    public interface ICategoryRepo
    {
        Task<List<RecipeCategory>> GetCategories();
    }
}
