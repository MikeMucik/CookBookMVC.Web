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
		private readonly IDifficultyService _difficultyService;
		private readonly ITimeService _timeService;
		public RecipeController(IRecipeService recipeService, ICategoryService categoryService, IDifficultyService difficultyService, ITimeService timeService)
		{
			_recipeService = recipeService;
			_categoryService = categoryService;
			_difficultyService = difficultyService;
			_timeService = timeService;
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
			var model = _recipeService.GetAllRecipesForList(20, 1, "");
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
			FillViewBags();

			return View(new NewRecipeVm());
		}

		[HttpPost]
		public IActionResult AddRecipe(NewRecipeVm model)
		{
			if (ModelState.IsValid)
			{
				if (model.TimeId.HasValue)
				{
					Console.WriteLine("TimeId ma wartość");
					var selectedTime = _timeService.GetTimeById((int)model.TimeId);
					if (selectedTime != null)
					{
						model.TimeAmount = selectedTime.Amount;
						model.TimeUnit = selectedTime.Unit;
					}
				}
				else
				if (model.TimeAmount != 0 && !string.IsNullOrEmpty(model.TimeUnit))
				{
					var newTime = new TimeForListVm
					{
						Amount = (int)model.TimeAmount,
						Unit = model.TimeUnit
					};
					model.TimeId = _timeService.AddTimeToRecipe(newTime);
				}
				else
				{
					ModelState.AddModelError("", "You must select existing time or provide new time");
					FillViewBags();
					return View(model);
				}
				var id = _recipeService.AddRecipe(model);
				return RedirectToAction("Index");
			}
			else { Console.WriteLine(Console.Error); }
			
			FillViewBags();

			return View(model);
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
		public void FillViewBags()
		{
			var categoryListVm = _categoryService.GetListCategoryForList();
			ViewBag.Categories = categoryListVm.Categories.Select(categ => new SelectListItem
			{
				Value = categ.Id.ToString(),
				Text = categ.Name
			}).ToList();
			foreach (var item in ViewBag.Categories)
			{
				Console.WriteLine($"Category: {item.Text}, Value: {item.Value}");
			}
			var difficultyListVm = _difficultyService.GetListDifficultyForList();
			ViewBag.Difficulties = difficultyListVm.Difficulties.Select(diff => new SelectListItem
			{
				Value = diff.Id.ToString(),
				Text = diff.Name
			}).ToList();
			foreach (var item in ViewBag.Difficulties)
			{
				Console.WriteLine($"Difficulty: {item.Text}, Value: {item.Value}");
			}
			var timeListVm = _timeService.GetListTimeForList();
			ViewBag.Times = timeListVm.Times.Select(tim => new SelectListItem
				{
					Value = tim.Id.ToString(),
					Text = tim.Amount.ToString() + " " + tim.Unit
				});
			foreach (var item in ViewBag.Times)
			{
				Console.WriteLine($"Time: {item.Text}, Value: {item.Value}");
			}
		}

	}
}
