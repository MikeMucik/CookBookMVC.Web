using CookBookMVC.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CookBookMVC.Web.Controllers
{
	public class RecipeController : Controller
	{
		public IActionResult Index()
		{
			//utworzyć widok dla tej akcji
			//tabela z przepisami
			//filtrowanie przepisów
			//przygotować dane
			//przekazać filtry do serwisu
			//serwis musi przygotować 
			//serwis musi zwrócić dane w odpowiednim formacie
			var model = recipeService.GetAllRecipesForList();
			return View(model);
		}

		[HttpGet]
		public IActionResult AddRecipe() 
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddRecipe(RecipeModel model)
		{
			var id = recipeServis.AddRecipe(model);
			return View();
		}
		[HttpGet]
		public IActionResult ViewRecipeDetails(int  id)
		{
			var recipeModel = recipeService.GetRecipeDetails(id);
			return View();
		}
	}
}
