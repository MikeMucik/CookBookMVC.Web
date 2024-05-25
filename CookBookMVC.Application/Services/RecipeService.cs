using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.ViewModels.Recipe;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.Services
{
	public class RecipeService : IRecipeService
	{
		private readonly IRecipeRepository _recipeRepo;
		private readonly IMapper _mapper;
        public RecipeService(IRecipeRepository recipeRepo, IMapper mapper)
        {
			_recipeRepo = recipeRepo;
			_mapper = mapper;            
        }
        public int AddRecipe(NewRecipeVm recipe)
		{
			throw new NotImplementedException();
		}

		public void DeleteRecipe(int recipeId)
		{
			throw new NotImplementedException();
		}
			

		public ListRecipeForListVm GetAllRecipesForList(int pageSize, int pageNo, string searchString)
		{
			var recipes = _recipeRepo.GetAllRecipes()
				.Where(r => r.Name.Contains(searchString))
				.ProjectTo<RecipeForListVm>(_mapper.ConfigurationProvider)
				.ToList();
			var recipesToShow = recipes
				.Skip(pageSize*(pageNo-1))
				.Take(pageSize)
				.ToList();
			var recipeVm = new ListRecipeForListVm()
			{
				PageSize = pageSize,
				CurrentPage = pageNo,
				SearchString = searchString,
				Recipes = recipesToShow,
				Count = recipes.Count
			};
			return recipeVm;

			//ListRecipeForListVm result = new ListRecipeForListVm();
			//result.Recipes = new List<RecipeForListVm>();
			//foreach (var recipe in recipes)
			//{
			//	var recipeVm = new RecipeForListVm()
			//	{
			//		Id = recipe.Id,
			//		Name = recipe.Name
			//	};
			//	result.Recipes.Add(recipeVm);
			//}
			//result.Count = result.Recipes.Count;
			//return result;
		}

		public RecipeDetailsVm GetRecipeDetails(int recipeId)
		{
			var recipe = _recipeRepo.GetRecipeById(recipeId);
			if (recipe == null)
			{
				throw new Exception("Recipe not found");
			}
			var recipeVm = _mapper.Map<RecipeDetailsVm>(recipe);
			recipeVm.Ingredients = new List<IngredientForListVm>();
			foreach (var ingredient in recipe.RecipeIngredient)
			{
				var ingVm = new IngredientForListVm
				{
					Id = ingredient.Ingredient.Id,
					Name = ingredient.Ingredient.Name,
					Quantity = ingredient.Quantity,
					Unit = ingredient.Ingredient.Unit,
				};
				recipeVm.Ingredients.Add(ingVm);
			}
			return recipeVm;
		}
	}
}
//var recipeVm = new RecipeDetailsVm
//{
//	Id = recipeId,
//	Name = recipe.Name,
//	CategoryName = recipe.Category.Name,
//	AmountOfIngredients = recipe.AmountOfIngredients,
//	DifficultyName = recipe.Difficulty.Name,
//	TimeName = recipe.Time.Amount + " " + recipe.Time.Unit,
//	Description = recipe.Description,

//	Ingredients = new List<IngredientForListVm>()
//};
//var recipeVm.Ingredients = new List<IngredientForListVm>()