using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Interfaces
{
    public interface IUserRepo
    {
        public void CreateUser(ApplicationUser user);
        public void UpdateUser(ApplicationUser user);
        public void DeleteUser(ApplicationUser user);
        public List<ApplicationUser> GetUsers();
    }
}
