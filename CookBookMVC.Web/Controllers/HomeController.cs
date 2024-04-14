using System.Diagnostics;
using CookBookMVC.Application.Interfaces;
using CookBookMVC.Domain.Model;
using CookBookMVC.Application.Services;
using CookBookMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CookBookMVC.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRecipeService _recipeServis;

        public HomeController(ILogger<HomeController> logger, IRecipeService recipeServis)
        {
            _logger = logger;
            _recipeServis = recipeServis;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //var recipes = DbContext.Recipes.Where(p => p.Name == "fried eggs");
            //IRecipeServis recipeServis = new RecipeServis();
            var recipes = _recipeServis.GetAllRecipes();
            return View();
        }
        [Route("Recipes/All")]
        public IActionResult ViewListOfRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();
            recipes.Add(new Recipe() { Id = 1, Name = "fried eggs", Category = "Breakfast" });
            recipes.Add(new Recipe() { Id = 2, Name = "sandwich", Category = "Breakfast" });
            recipes.Add(new Recipe() { Id = 3, Name = "milksoup", Category = "Breakfast" });
            return View(recipes);
        }
        [Route("Recipes/Recipe")]
        public IActionResult ViewRecipeDetails(int id, string name )
        {
            // int select = 2;
            List<Recipe> recipes = new List<Recipe>();
            recipes.Add(new Recipe() { Id = 1, Name = "fried eggs", Category = "Breakfast" });
            recipes.Add(new Recipe() { Id = 2, Name = "sandwich", Category = "Lunch" });
            recipes.Add(new Recipe() { Id = 3, Name = "milksoup", Category = "Breakfast" });
            if(id != 0)
            {
                var recipe = recipes.FirstOrDefault(p => p.Id == id);
                if (recipe != null)
                {
                    return View(recipe);
                }
            }
            else if (!string.IsNullOrEmpty(name))
            {
                var recipe = recipes.FirstOrDefault(p => p.Name == name);
                if (recipe != null)
                {
                    return View(recipe);
                }
            }
            return NotFound();
        }
        [Route("Recipes/Category")]
        public IActionResult ViewByCategory(string category)
        {
            List<Recipe> recipes = new List<Recipe>();
            recipes.Add(new Recipe() { Id = 1, Name = "fried eggs", Category = "Breakfast" });
            recipes.Add(new Recipe() { Id = 2, Name = "sandwich", Category = "Lunch" });
            recipes.Add(new Recipe() { Id = 3, Name = "milksoup", Category = "Breakfast" });

            if (!string.IsNullOrEmpty(category))
            {
                var recipesByCategory = recipes.Where(p => p.Category.ToUpper() == category.ToUpper()).ToList();
                return View(recipesByCategory);
            }
              else
            {
                return NotFound();
            }
        }

        [Route("Recipes/CategoryP")]
        public IActionResult ViewByCategoryPartial(string category)
        {
			List<Recipe> recipes = new List<Recipe>();
			recipes.Add(new Recipe() { Id = 1, Name = "fried eggs", CategoryId = 1 });//!!!!
			recipes.Add(new Recipe() { Id = 2, Name = "sandwich", Category = "Lunch" });
			recipes.Add(new Recipe() { Id = 3, Name = "milksoup", Category = "Breakfast" });
			if (!string.IsNullOrEmpty(category))
			{
				var recipesByCategory = recipes.Where(p => p.Category.ToUpper() == category.ToUpper()).ToList();
				return PartialView(recipesByCategory);
			}
			else
			{
				return NotFound();
			}

		}


        public IActionResult TestPartial()
        {
            return PartialView();
        }

        public IActionResult OkTest()
        {
            return Ok("Everything is ok");
        }

        //public IActionResult JsonTest()
        //{
        //    string a = "JSON";
        //    return new JsonResult(a);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
