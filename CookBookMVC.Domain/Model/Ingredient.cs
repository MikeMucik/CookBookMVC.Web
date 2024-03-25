using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookMVC.Domain.Model
{
	public class Ingredient
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Unit { get; set; }
		public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } 
	}
}
