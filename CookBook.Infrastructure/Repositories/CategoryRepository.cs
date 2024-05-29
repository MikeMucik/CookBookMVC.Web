using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Infrastructure;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Infrastructure.Repositories
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly Context _context;
		public CategoryRepository(Context context)
		{
			_context = context;
		}

		public int AddCategory(Category category)
		{
			_context.Categories.Add(category);
			_context.SaveChanges();
			return category.Id;
		}

		public void DeleteCategory(int categoryId)
		{
			var category = _context.Categories.Find(categoryId);
			if (category != null)
			{
				_context.Categories.Remove(category);
				_context.SaveChanges();
			}
		}

		public IQueryable<Category> GetAllCategories()
		{
			return _context.Categories;
		}
	}
}
