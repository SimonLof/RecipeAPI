namespace RecipeAPI.Domain.DTO
{
    public class RecipeCreationDTO
    {
        // recipe som skickas in för att skapa ett nytt recept.
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public int CategoryID { get; set; }
    }
}
