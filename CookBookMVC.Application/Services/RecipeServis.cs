using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.ViewModels.Recipe;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.Services
{
	public class RecipeServis : IRecipeServis
	{
		private readonly IRecipeRepository _recipeRepo;
		public int AddRecipe(NewRecipeVm recipe)
		{
			throw new NotImplementedException();
		}

		public void DeleteRecipe(int recipeId)
		{
			throw new NotImplementedException();
		}

		//public List<int> GetAllRecipes()
		//{
		//	var recipes = new List<int>();
		//	return recipes;
		//}

		public RecipeDetailsVm GetRecipeDetails(int recipeId)
		{
			var recipe = _recipeRepo.GetRecipeById(recipeId);
			var recipeVm = new RecipeDetailsVm();
			recipeVm.Id = recipe.Id;
			recipeVm.Name = recipe.Name;
			recipeVm.Description = recipe.Description;
			var ingredientsOfRecipe = recipe.RecipeIngredients;
			List<Ingredient> recipeVmIngredients = new List<Ingredient>();
            foreach (var item in recipeVmIngredients)
            {
                if (item.Id == recipe.Ingredients.)
                {
                    recipeVmIngredients.Add(item);
                }
                
            }
            recipeVmIngredients = ingredientsOfRecipe.All(x => x.Id == recipe.RecipeIngredients. );
			//recipeVm.Ingredients.AddRange(ingredientsOfRecipe.Select(x => x.RecipeId == RecipeIngredient.Equals());
			recipeVm.TimeName = recipe.Time.Amount + ":" + recipe.Time.Unit;
			recipeVm.DifficultyName = recipe.Difficulty.Name;
			


				return recipeVm;
		}

		public ListRecipeForListVm GetAllRecipesForList()
		{
			var recipes = _recipeRepo.GetAllRecipes();
			ListRecipeForListVm result = new ListRecipeForListVm();
			result.Recipes = new List<RecipeForListVm>();
			foreach (var recipe in recipes)
			{
				var recipeVm = new RecipeForListVm()
				{
					Id = recipe.Id,
					Name = recipe.Name
				};
				result.Recipes.Add(recipeVm);
			}
			result.Count = result.Recipes.Count;
			return result;
		}
	}
}
