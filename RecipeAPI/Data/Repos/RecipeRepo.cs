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

        public Task<ApplicationUser> GetUser(int userID)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserID == userID);
            if (user is null) throw new Exception("User not found.");

            return Task.FromResult(user);
        }

        public Task<RecipeCategory> GetCategory(int categoryID)
        {
            var category = _context.RecipeCategories.SingleOrDefault(c => c.CategoryID == categoryID);
            if (category is null) throw new Exception("Category not found");

            return Task.FromResult(category);
        }


        public Task CreateRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<List<Recipe>> GetRecipes()
        {
            return Task.FromResult(_context.Recipes
                .Include("Category")
                .Include("User")
                .Include("Ratings")
                .ToList());
        }

        public Task<List<Recipe>> SearchRecipes(string searchCondition)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe> GetRecipe(int id)
        {
            var recipe = _context.Recipes
                .Include("Category")
                .Include("User")
                .Include("Ratings")
                .SingleOrDefault(r => r.RecipeID == id);
            if (recipe is null) throw new Exception("Recipe not found");

            return Task.FromResult(recipe);
        }
    }
}


//public virtual List<Rating> Ratings { get; set; }
//public virtual RecipeCategory Category { get; set; }
//public virtual ApplicationUser User { get; set; }