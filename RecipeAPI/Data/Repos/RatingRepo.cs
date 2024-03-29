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

        public Task<ApplicationUser> GetApplicationUser(int id)
        {
            return Task.FromResult<ApplicationUser>(
                _context.Users.SingleOrDefault(u => u.UserID == id));
        }

        public Task<Recipe> GetRecipe(int id)
        {
            // Måste köra .Include().ThenInclude() för att inkludera saker "längre bort" i databasen.
            return Task.FromResult<Recipe>(_context.Recipes
                .Include(r => r.User)
                .Include(r => r.Ratings)
                .ThenInclude(r => r.FromUser)
                .SingleOrDefault(r => r.RecipeID == id));
        }

        public Task<Recipe> PostNewRating(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();

            return Task.FromResult(rating.OnRecipe);
        }
    }
}
