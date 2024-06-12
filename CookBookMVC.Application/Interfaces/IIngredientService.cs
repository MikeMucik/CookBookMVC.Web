using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.ViewModels.Ingredient;


namespace CookBookMVC.Application.Interfaces
{
    public interface IIngredientService
	{
		int AddIngredient(IngredientForListVm ingredient);
		ListIngredientNotQuantityVm GetAllIngredients();
		IngredientNotQuantityForListVm GetIngredientById(int id);
	}
}
