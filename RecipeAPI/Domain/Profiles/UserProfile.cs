using AutoMapper;
using RecipeAPI.Domain.DTO;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Domain.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, ApplicationUser>();
        }
    }
}
