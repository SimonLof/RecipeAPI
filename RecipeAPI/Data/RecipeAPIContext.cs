using Microsoft.EntityFrameworkCore;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data
{
    public class RecipeAPIContext : DbContext
    {
        public RecipeAPIContext(DbContextOptions<RecipeAPIContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Säger åt EF att inte cascade-deleta användare och recept om man tar bort en rating.

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.FromUser)
                .WithMany(u => u.Ratings)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.OnRecipe)
                .WithMany(re => re.Ratings)
                .OnDelete(DeleteBehavior.NoAction);

            // Såhär gör man en composite key i databasen, istället för att ha med ett ID.
            // Skulle funka i det här fallet, eftersom en användare bara får lägga en röst på varje recept.
            // Men jag lärde mig det försent så det är ID nu.
            //modelBuilder.Entity<Rating>()
            //    .HasKey(r => new { r.FromUser, r.OnRecipe });
        }

        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeCategory> RecipeCategories { get; set; }
        public virtual DbSet<ApplicationUser> Users { get; set; }

    }
}
