using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> CreateUser(UserDTO userDTO);
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> UpdateUser(UserDTO user);
        Task DeleteUser(int userID);
        Task<UserDTO> GetUserById(int userID);
        Task<object> Login(UserLoginDTO loginDTO);
    }
}
