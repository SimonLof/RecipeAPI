using Microsoft.EntityFrameworkCore;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Repos
{
    public class RatingRepo : IRatingRepo
    {
        private readonly RecipeAPIContext _context;

        public RatingRepo(RecipeAPIContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser> GetApplicationUser(int id)
        {
            return await Task.Run(() => _context.Users.SingleOrDefault(u => u.UserID == id));
        }

        public async Task<Recipe> GetRecipe(int id)
        {
            return await Task.Run(() => _context.Recipes.Include("User").SingleOrDefault(r => r.RecipeID == id));
        }

        public async Task<Recipe> PostNewRating(Rating rating)
        {
            await Task.Run(() =>
            {
                _context.Ratings.Add(rating);
                _context.SaveChanges();
            });
            return rating.OnRecipe;
        }
    }
}
