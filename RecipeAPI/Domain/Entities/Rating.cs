using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Domain.Entities
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        public int Score { get; set; }

        public virtual ApplicationUser FromUser { get; set; }
        public virtual Recipe OnRecipe { get; set; }
    }
}
