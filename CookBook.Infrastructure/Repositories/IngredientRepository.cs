using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Infrastructure;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Infrastructure.Repositories
{
	public class IngredientRepository : IIngredientRepository
	{
		private readonly Context _context;
		public IngredientRepository(Context context)
		{
			_context = context;
		}
		public int AddIngredient(Ingredient ingredient)
		{
			_context.Ingredients.Add(ingredient);
			_context.SaveChanges();
			return ingredient.Id;
		}

		public void DeleteIngredient(int ingredientId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Ingredient> GetAll()
		{
			return _context.Ingredients.ToList();
		}

		public Ingredient GetIngredientById(int id)
		{
			return _context.Ingredients.Find(id);
		}
	}
}
