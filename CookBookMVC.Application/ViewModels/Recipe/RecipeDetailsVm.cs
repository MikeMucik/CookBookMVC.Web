using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.ViewModels.Recipe
{
	public class RecipeDetailsVm : IMapFrom<CookBookMVC.Domain.Model.Recipe>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		
		public string CategoryName { get; set; }
		public int AmountOfIngredients { get; set; }
		public List<IngredientForListVm> Ingredients { get; set; } 
		public string DifficultyName { get; set; }		
		public string TimeName { get; set; }
		public string Description { get; set; }
		public void Mapping(Profile profile)
		{
			profile.CreateMap<CookBookMVC.Domain.Model.Recipe, RecipeDetailsVm>()
				.ForMember(q => q.CategoryName, opt => opt.MapFrom(w => w.Category.Name))
				.ForMember(q => q.DifficultyName, opt => opt.MapFrom(w => w.Difficulty.Name))
				.ForMember(q => q.TimeName, opt => opt.MapFrom(w => w.Time.Amount + " " + w.Time.Unit))
				.ForMember(q => q.AmountOfIngredients, opt => opt.MapFrom(w => w.AmountOfIngredients))
                .ForMember(q => q.Ingredients, opt => opt.MapFrom(w => w.RecipeIngredient.Select(i => new IngredientForListVm
                {
                    Id = i.Ingredient.Id,
                    Name = i.Ingredient.Name,
                    Quantity = i.Quantity, // lub odpowiednia właściwość
                    Unit = i.Ingredient.Unit
                }).ToList())); 				
		}
	}
}
