using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.ViewModels.Ingredient;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.Services
{
    public class IngredientService : IIngredientService
	{
		private readonly IIngredientRepository _ingredientRepo;
		private readonly IMapper _mapper;
		public IngredientService(IIngredientRepository ingredientRepo, IMapper mapper)
		{
			_ingredientRepo = ingredientRepo;
			_mapper = mapper;
		}

		public int AddIngredient(IngredientForListVm ingredient)
		{
			var ingredientAdd = _mapper.Map<Ingredient>(ingredient);
			var ingredientId = _ingredientRepo.AddIngredient(ingredientAdd);
			return ingredientId;
		}

		public ListIngredientNotQuantityVm GetAllIngredients()
		{
			var ingredients = _ingredientRepo.GetAll();
			var ingredientVms = _mapper.Map<List<IngredientNotQuantityForListVm>>(ingredients);
			var ingredientList = new ListIngredientNotQuantityVm
			{
				Ingredients = ingredientVms,
			};
			return ingredientList;
			
		}

		public IngredientNotQuantityForListVm GetIngredientById(int id)
		{
			var ingredientSelected = _ingredientRepo.GetIngredientById(id);
			var ingredientVms = _mapper.Map<IngredientNotQuantityForListVm>(ingredientSelected);
			return ingredientVms;
			
		}
	}
}
