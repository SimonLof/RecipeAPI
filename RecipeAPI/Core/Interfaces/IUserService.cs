using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Core.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserDTO userDTO);
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> UpdateUser(UserDTO user);

        Task<object> Login(UserLoginDTO loginDTO);
    }
}
