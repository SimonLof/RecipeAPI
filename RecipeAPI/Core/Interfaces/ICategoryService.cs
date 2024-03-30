using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Core.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryViewDTO>> GetAllCategories();
    }
}
