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

        public async Task<List<RecipeCategory>> GetRecipeCategories()
        {
            var recipeCategoryList = new List<RecipeCategory>();
            await Task.Run(() =>
            {
                recipeCategoryList = _context.RecipeCategories.ToList();
            });
            return recipeCategoryList;
        }
    }
}
