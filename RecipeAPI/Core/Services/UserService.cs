using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.DTO;
using RecipeAPI.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RecipeAPI.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<UserDTO> CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<ApplicationUser>(userDTO);

            return _mapper.Map<UserDTO>(await _repo.CreateUser(user));
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var userReturn = new List<UserDTO>();

            var appUser = await _repo.GetUsers();

            foreach (var user in appUser)
            {
                userReturn.Add(_mapper.Map<UserDTO>(user));
            }

            return userReturn;
        }

        public async Task<UserDTO> UpdateUser(UserDTO user)
        {
            if (user is null) throw new Exception("Invalid user.");

            var updateUser = _mapper.Map<ApplicationUser>(user);
            try
            {
                await _repo.UpdateUser(updateUser);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> Login(UserLoginDTO loginDTO)
        {
            if (string.IsNullOrEmpty(loginDTO.UserName))
                throw new Exception("Username required.");

            if (string.IsNullOrEmpty(loginDTO.Password))
                throw new Exception("Password required.");

            var user = await _repo.Login(loginDTO);

            if (user == null)
                throw new Exception("Failed login.");

            List<Claim> claims =
            [
                new Claim(ClaimTypes.NameIdentifier, user.UserID.ToString()),
                new Claim(ClaimTypes.Role,"appUser"),

            ];

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("mysecretKey12345!#123456789101112"));

            var signInCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
               issuer: "http://localhost:5025/",
               audience: "http://localhost:5025/",
               claims: claims,
               expires: DateTime.Now.AddHours(1),
               signingCredentials: signInCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new { Token = tokenString };
        }


        public async Task DeleteUser(int userID)
        {
            try
            {
                await _repo.DeleteUser(userID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserDTO> GetUserById(int userID)
        {
            return _mapper.Map<UserDTO>(await _repo.GetUserById(userID));
        }
    }
}
