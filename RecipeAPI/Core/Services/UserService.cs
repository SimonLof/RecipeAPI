using AutoMapper;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.DTO;
using RecipeAPI.Domain.Entities;

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

        public void CreateUser(UserDTO userDTO)
        {
            var user = _mapper.Map<ApplicationUser>(userDTO);

            _repo.CreateUser(user);
        }
    }
}
