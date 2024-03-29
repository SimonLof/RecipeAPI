using RecipeAPI.Domain.DTO;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Data.Interfaces
{
    public interface IUserRepo
    {
        public Task<ApplicationUser> CreateUser(ApplicationUser user);
        public Task UpdateUser(ApplicationUser user);
        public Task DeleteUser(int userID);
        public Task<ApplicationUser> GetUserById(int id);
        public Task<List<ApplicationUser>> GetUsers();
        Task<ApplicationUser> Login(UserLoginDTO userLogin);
    }
}
