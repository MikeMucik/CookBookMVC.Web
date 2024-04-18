using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Domain.Interface
{
	public interface IRecipeRepository
	{
		void DeleteRecipe(int recipeId);

		int AddRecipe(Recipe recipe);

		int UpdateRecipe(Recipe recipe);

		IQueryable<Recipe> GetRecipesByCategoryId(int categoryId);

		Recipe GetRecipeById(int id);

		IQueryable<Category> GetAllCategories();
		
	}
}
