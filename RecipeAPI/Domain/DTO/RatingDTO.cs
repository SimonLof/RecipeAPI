namespace RecipeAPI.Domain.DTO
{
    public class RatingDTO
    {
        public int UserID { get; set; }
        public int RecipeID { get; set; }
        public int Score { get; set; }
    }
}
