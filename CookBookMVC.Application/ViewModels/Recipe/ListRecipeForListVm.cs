using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookMVC.Application.ViewModels.Recipe
{
	public class ListRecipeForListVm
	{
		public List<RecipeForListVm> Recipes { get; set; }
		public int CurrentPage { get; set; }
		public int PageSize { get; set; }
		public string SearchString { get; set; }
		public int Count { get; set; }
	}
}
