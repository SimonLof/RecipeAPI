namespace RecipeAPI.Domain.DTO
{
    public class RecipeViewDTO
    {
        // Recipe som visas upp när man hämtar från databasen.
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredient { get; set; }
        public List<int> Ratings { get; set; }
        public int AvgRating { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }
    }
}
