using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.ViewModels.Category;

namespace CookBookMVC.Application.Interfaces
{
    public interface ICategoryService
	{
		int AddCategory(CategoryForListVm category);
		void DeleteCategory(int categoryId);
		ListCategoryForListVm GetListCategoryForList();
	}
}
