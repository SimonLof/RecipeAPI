using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Core.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(UserDTO userDTO);
    }
}
