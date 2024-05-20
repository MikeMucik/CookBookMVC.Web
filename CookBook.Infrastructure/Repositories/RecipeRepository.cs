using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure.Repositories
{
	public class RecipeRepository: IRecipeRepository
	{
        private readonly Context _context;
        public RecipeRepository(Context context)
        {
            _context = context;
        }

        public int AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
            return recipe.Id;
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

        public int UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
            return recipe.Id;
        }
        

        public IQueryable<Recipe> GetRecipesByCategoryId(int categoryId)
        {
            var recipes = _context.Recipes.Where(r => r.CategoryId == categoryId);
            return recipes;
        }

        public Recipe GetRecipeById (int recipeId)
        {
            var recipe = _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Difficulty)
                .Include(r => r.Time)
                .Include(r => r.RecipeIngredient)
                    .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefault(r => r.Id == recipeId);                ;
            return recipe;
        }

        public IQueryable<Category> GetAllCategories()
        {
            var categories = _context.Categories;
            return categories;
        }

		public IQueryable<Recipe> GetAllRecipes()
		{
            return _context.Recipes;
		}
	}
}
