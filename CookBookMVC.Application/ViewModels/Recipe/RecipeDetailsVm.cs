using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.ViewModels.Recipe
{
	public class RecipeDetailsVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public List<ListIngredientsForRecipeVm> Ingredients { get; set; }
		public int CategoryId{ get; set; }
		public string CategoryName { get; set; }
		public int DifficultyId { get; set; } 
		public string DifficultyName { get; set; }
		public int TimeId { get; set; }
		public string TimeName { get; set; }
		public string Description { get; set; }
	}
}
