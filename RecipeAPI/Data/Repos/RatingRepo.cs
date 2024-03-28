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
            // Måste köra .Include().ThenInclude() för att få saker "längre bort" i databasen.
            return _context.Recipes.Include(r => r.User)
                .Include(r => r.Ratings)
                .ThenInclude(r => r.FromUser)
                .SingleOrDefault(r => r.RecipeID == id);
        }

        public async Task<Recipe> PostNewRating(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();

            return rating.OnRecipe;
        }
    }
}
