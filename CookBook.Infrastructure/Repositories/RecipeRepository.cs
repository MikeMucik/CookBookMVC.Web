using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBook.Infrastructure.Repositories
{
	public class RecipeRepository: IRecipeRepository
	{
        private readonly Context _context;
        public RecipeRepository(Context context)
        {
            _context = context;
        }
        public void DeleteRecipe(int recipeId)
        {
            var recipe = _context.Recipes.Find(recipeId);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                _context.SaveChanges();
            }
        }
        public int AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return recipe.Id;
        }
        public IQueryable<Recipe> GetRecipesByCategoryId(int categoryId)
        {
            var recipes = _context.Recipes.Where(r => r.CategoryId == categoryId);
            return recipes;
        }
        public Recipe GetRecipeById (int id)
        {
            var recipe = _context.Recipes.FirstOrDefault(r => r.Id == id);
            return recipe;
        }
        public IQueryable<Category> GetAllCategories()
        {
            var categories = _context.Categories;
            return categories;
        }
    }
}
