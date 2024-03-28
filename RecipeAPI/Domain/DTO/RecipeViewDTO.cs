namespace RecipeAPI.Domain.DTO
{
    public class RecipeViewDTO
    {
        // Recipe som visas upp när man hämtar från databasen.
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public List<int> Ratings { get; set; }
        public decimal AvgRating { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
    }
}
