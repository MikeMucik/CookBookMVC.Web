using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookMVC.Domain.Model
{
	public class RecipeIngredient
	{
		public int Id { get; set; } //czy to potrzebne
		public int RecipeId { get; set; }
		public virtual Recipe Recipe { get; set; }
		public int IngredientId { get; set; }
		public virtual Ingredient Ingredient { get; set; }
		//public int Quantity { get; set; }//tu usuwam i wstawiam no Ingredient
	}
}
