using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly RecipeAPIContext _context;

        public CategoryRepo(RecipeAPIContext context)
        {
            _context = context;
        }

        public Task<List<RecipeCategory>> GetCategories()
        {
            var recipeCategoryList = _context.RecipeCategories.ToList();

            return Task.FromResult(recipeCategoryList);
        }
    }
}
