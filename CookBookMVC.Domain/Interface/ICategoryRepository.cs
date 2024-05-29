using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Domain.Interface
{
	public interface ICategoryRepository
	{
		int AddCategory (Category category);
		void DeleteCategory(int categoryId);
		IQueryable<Category> GetAllCategories();
	}
}
