using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Interfaces
{
    public interface IUserRepo
    {
        public Task CreateUser(ApplicationUser user);
        public Task UpdateUser(ApplicationUser user);
        public Task DeleteUser(ApplicationUser user);
        public Task<List<ApplicationUser>> GetUsers();
    }
}
