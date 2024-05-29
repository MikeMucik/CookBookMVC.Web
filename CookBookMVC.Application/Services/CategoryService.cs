using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.ViewModels.Recipe;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;
using AutoMapper.QueryableExtensions;

namespace CookBookMVC.Application.Services
{
	public class CategoryService : ICategoryService
	{
		private readonly ICategoryRepository _categoryRepo;
		private readonly IMapper _mapper;
		public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
		{
			_categoryRepo = categoryRepository;
			_mapper = mapper;
		}

		public int AddCategory(CategoryForListVm category)
		{
			var categoryAdd = _mapper.Map<Category>(category);
			var categoryId = _categoryRepo.AddCategory(categoryAdd);
			return categoryId;
		}

		public void DeleteCategory(int id)
		{
			throw new NotImplementedException();
		}

		public ListCategoryForListVm GetListCategoryForList()
		{
			
			var categories = _categoryRepo.GetAllCategories()
				.ProjectTo<CategoryForListVm>(_mapper.ConfigurationProvider)
				.ToList();
			var categoryList = new ListCategoryForListVm()
			{
				Categories = categories
			};
			return categoryList;// tu może jest źle
		}
	}
}
