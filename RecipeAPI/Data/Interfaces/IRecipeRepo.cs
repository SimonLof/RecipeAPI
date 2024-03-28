using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Interfaces
{
    public interface IRecipeRepo
    {
        public Task CreateRecipe(Recipe recipe);
        public Task UpdateRecipe(Recipe recipe);
        public Task DeleteRecipe(Recipe recipe);
        public Task<Recipe> GetRecipe(int id);
        public Task<List<Recipe>> GetRecipes();
        public Task<List<Recipe>> SearchRecipes(string searchCondition);
        public Task<ApplicationUser> GetUser(int userID);
        public Task<RecipeCategory> GetCategory(int categoryID);
    }
}
