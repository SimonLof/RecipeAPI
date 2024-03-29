using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Repos
{
    public class TestRepo : ITestRepo
    {
        private readonly RecipeAPIContext _context;

        public TestRepo(RecipeAPIContext context)
        {
            _context = context;
        }

        public Task<List<RecipeCategory>> GetRecipeCategories()
        {
            var recipeCategoryList = new List<RecipeCategory>();

            recipeCategoryList = _context.RecipeCategories.ToList();

            return Task.FromResult(recipeCategoryList);
        }
    }
}
