using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Domain.Entities
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(512)]
        public string Description { get; set; }
        [StringLength(512)]
        public string Ingredients { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual RecipeCategory Category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
