using AutoMapper;
using RecipeAPI.Domain.DTO;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Domain.Profiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            // den här är one way från recipe till view.
            CreateMap<Recipe, RecipeViewDTO>()

                .ForMember(dest => dest.Ratings,
                option =>

                option.MapFrom(src => src.Ratings.Select(rate => rate.Score).ToList()))

                .ForMember(dest => dest.CategoryName,
                option =>

                option.MapFrom(src => src.Category.Name))

                .ForMember(dest => dest.UserName,
                option =>

                option.MapFrom(src => src.User.UserName))

                .ForMember(dest => dest.AvgRating,
                option =>

                option.MapFrom(src => src.Ratings.Count > 0 ?
                    src.Ratings.Select(r => r.Score).Average() : 0));
        }
    }
}