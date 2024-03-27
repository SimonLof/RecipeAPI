using RecipeAPI.Core.Interfaces;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Core.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepo _testRepo;

        public TestService(ITestRepo testRepo)
        {
            _testRepo = testRepo;
        }

        public async Task<List<RecipeCategory>> GetAllRecipeCategories()
        {
            return await _testRepo.GetRecipeCategories();
        }
    }
}
