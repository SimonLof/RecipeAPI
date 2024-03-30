using AutoMapper;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.DTO;

namespace RecipeAPI.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _testRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepo testRepo, IMapper mapper)
        {
            _testRepo = testRepo;
            _mapper = mapper;
        }

        public async Task<List<CategoryViewDTO>> GetAllCategories()
        {
            var categories = await _testRepo.GetCategories();

            List<CategoryViewDTO> result = [];
            foreach (var category in categories)
            {
                result.Add(_mapper.Map<CategoryViewDTO>(category));
            }

            return result;
        }
    }
}
