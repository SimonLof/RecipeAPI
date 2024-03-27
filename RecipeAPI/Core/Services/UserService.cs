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

        public Task CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<ApplicationUser>(userDTO);

            return _repo.CreateUser(user);
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

        public Task<UserDTO> UpdateUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public async Task<object> Login(UserLoginDTO loginDTO)
        {
            if (string.IsNullOrEmpty(loginDTO.UserName))
                throw new ArgumentNullException(paramName: "username");

            if (string.IsNullOrEmpty(loginDTO.Password))
                throw new ArgumentNullException(paramName: "password");

            var allUsers = await _repo.GetUsers();

            var user = allUsers.SingleOrDefault(u =>
                    u.UserName.ToLower() == loginDTO.UserName.ToLower() && u.Password == loginDTO.Password);

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
               expires: DateTime.Now.AddMinutes(20),
               signingCredentials: signInCredentials
                );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return new { Token = tokenString };
        }
    }
}
