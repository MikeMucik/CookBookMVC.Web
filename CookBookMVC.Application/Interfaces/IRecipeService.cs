using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.ViewModels.Recipe;

namespace CookBookMVC.Application.Interfaces
{
    public interface IRecipeService
    {
        
        int AddRecipe(NewRecipeVm recipe);

        void DeleteRecipe(int recipeId);

        ListRecipeForListVm GetAllRecipesForList(int pageSize, int pageNo, string searchString);

        RecipeDetailsVm GetRecipeDetails(int recipeId);
	}
    
}
