using CookBookMVC.Application.Interfaces;
using System.Linq;
using CookBookMVC.Application.ViewModels.Recipe;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace CookBookMVC.Web.Controllers
{
	public class RecipeController : Controller
	{
		private readonly IRecipeService _recipeService;
		private readonly ICategoryService _categoryService;
		public RecipeController(IRecipeService recipeService)
		{
			_recipeService = recipeService;

		}
		public RecipeController(IRecipeService recipeService, ICategoryService categoryService) 
		{
			_recipeService = recipeService;
			_categoryService = categoryService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			//utworzyć widok dla tej akcji
			//tabela z przepisami
			//filtrowanie przepisów
			//przygotować dane
			//przekazać filtry do serwisu
			//serwis musi przygotować 
			//serwis musi zwrócić dane w odpowiednim formacie
			var model = _recipeService.GetAllRecipesForList(3, 1, "");
			return View(model);
		}

		[HttpPost]
		public IActionResult Index(int pageSize, int? pageNo, string searchString)
		{
			if (!pageNo.HasValue)
			{
				pageNo = 1;
			}
			if (searchString is null)
			{
				searchString = string.Empty;
			}
			var model = _recipeService.GetAllRecipesForList(pageSize, (int)pageNo, searchString);
			return View(model);

		}

		[HttpGet]
		public IActionResult AddRecipe()
		{
			var category = _categoryService.GetListCategoryForList();
			//ViewBag.Category = category.Select(categ => new SelectListItem
			//{
			//	Value = categ.Id.ToString(),
			//	Text = categ.Name
			//}).ToList();
			return View(new NewRecipeVm());
		}
		[HttpPost]
		public IActionResult AddRecipe(NewRecipeVm model)
		{
			var id = _recipeService.AddRecipe(model);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult ViewRecipeDetails(int id)
		{
			var recipeModel = _recipeService.GetRecipeDetails(id);
			if (recipeModel == null)
			{
				return View("Error");
			}

			return View(recipeModel);
		}

	}
}
