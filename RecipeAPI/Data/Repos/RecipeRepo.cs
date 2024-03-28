using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Repos
{
    public class RecipeRepo : IRecipeRepo
    {
        private readonly RecipeAPIContext _context;

        public RecipeRepo(RecipeAPIContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetUser(int userID)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserID == userID);
            if (user is null) throw new Exception("User not found.");

            return user;
        }

        public async Task<RecipeCategory> GetCategory(int categoryID)
        {
            var category = _context.RecipeCategories.SingleOrDefault(c => c.CategoryID == categoryID);
            if (category is null) throw new Exception("Category not found");

            return category;
        }


        public async Task CreateRecipe(Recipe recipe)
        {
            await Task.Run(() =>
            {
                _context.Recipes.Add(recipe);
                _context.SaveChanges();
            });
        }

        public Task DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Recipe>> GetRecipes()
        {
            return _context.Recipes
                .Include("Category")
                .Include("User")
                .Include("Ratings")
                .ToList();
        }

        public Task<List<Recipe>> SearchRecipes(string searchCondition)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            var recipe = _context.Recipes
                .Include("Category")
                .Include("User")
                .Include("Ratings")
                .SingleOrDefault(r => r.RecipeID == id);
            if (recipe is null) throw new Exception("Recipe not found");

            return recipe;
        }
    }
}


//public virtual List<Rating> Ratings { get; set; }
//public virtual RecipeCategory Category { get; set; }
//public virtual ApplicationUser User { get; set; }