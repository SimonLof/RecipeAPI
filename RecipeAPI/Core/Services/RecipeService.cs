﻿using AutoMapper;
using RecipeAPI.Core.Interfaces;
using RecipeAPI.Data.Interfaces;
using RecipeAPI.Domain.DTO;
using RecipeAPI.Domain.Entities;

namespace RecipeAPI.Core.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepo _recipeRepo;
        private readonly IMapper _mapper;

        public RecipeService(IRecipeRepo recipeRepo, IMapper mapper)
        {
            _recipeRepo = recipeRepo;
            _mapper = mapper;
        }

        public async Task<RecipeViewDTO> CreateRecipe(RecipeCreationDTO recipe, string userID)
        {
            if (recipe is null) throw new ArgumentNullException(nameof(recipe));

            var user = await _recipeRepo.GetUser(int.Parse(userID));
            var category = await _recipeRepo.GetCategory(recipe.CategoryID);

            var newRecipe = new Recipe()
            {
                Category = category,
                Description = recipe.Description,
                Ingredients = recipe.Ingredients,
                Name = recipe.Name,
                Ratings = [],
                User = user,
            };

            await _recipeRepo.CreateRecipe(newRecipe);

            var readableRecipe = _mapper.Map<RecipeViewDTO>(newRecipe);


            return readableRecipe;
        }

        public async Task<string> DeleteRecipe(int id, int userID)
        {
            var recipe = await _recipeRepo.GetRecipe(id);
            if (recipe.User.UserID != userID) throw new Exception("Can only delete your own recipes.");

            return await _recipeRepo.DeleteRecipe(id);
        }

        public async Task<List<RecipeViewDTO>> GetAllRecipes()
        {
            var recipes = await _recipeRepo.GetRecipes();
            List<RecipeViewDTO> readableRecipes = [];

            foreach (var item in recipes)
            {
                readableRecipes.Add(_mapper.Map<RecipeViewDTO>(item));
            }

            return readableRecipes;
        }

        public async Task<RecipeViewDTO> GetRecipe(int id)
        {
            return _mapper.Map<RecipeViewDTO>(await _recipeRepo.GetRecipe(id));
        }

        public async Task<List<RecipeViewDTO>> SearchRecipe(string searchCondition)
        {
            var results = await _recipeRepo.SearchRecipes(searchCondition);

            List<RecipeViewDTO> readableResults = [];
            foreach (var recipe in results)
            {
                readableResults.Add(_mapper.Map<RecipeViewDTO>(recipe));
            }
            return readableResults;
        }

        public async Task<RecipeViewDTO> UpdateRecipe(RecipeCreationDTO recipe, int recipeID, int userID)
        {
            var recipeToUpdate = await _recipeRepo.GetRecipe(recipeID);

            if (recipeToUpdate.User.UserID != userID) throw new Exception("Can only update your own recipes.");

            recipeToUpdate.Category = await _recipeRepo.GetCategory(recipe.CategoryID);
            recipeToUpdate.Description = recipe.Description;
            recipeToUpdate.Ingredients = recipe.Ingredients;
            recipeToUpdate.Name = recipe.Name;

            return _mapper.Map<RecipeViewDTO>(await _recipeRepo.UpdateRecipe(recipeToUpdate));
        }
    }
}
