using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Domain.Entities
{
    public class ApplicationUser
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Email { get; set; }

        public virtual List<Recipe> UsersRecipes { get; set; }
        public virtual List<Rating> Ratings { get; set; }
    }
}
