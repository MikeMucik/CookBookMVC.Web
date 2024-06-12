using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Domain.Interface
{
	public interface IIngredientRepository
	{
		int AddIngredient(Ingredient ingredient);
		void DeleteIngredient(int ingredientId);
		IEnumerable<Ingredient> GetAll();
		Ingredient GetIngredientById(int id);
	}
}
