using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Domain.Entities
{
    public class RecipeCategory
    {
        [Key]
        public int CategoryID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Description { get; set; }

        public virtual List<Recipe> Recipes { get; set; }
    }
}
