using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;

namespace CookBookMVC.Application.ViewModels.Recipe
{
	public class RecipeForListVm : IMapFrom<CookBookMVC.Domain.Model.Recipe>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; } // to dodałem bo lista samych nazw jest za mało

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CookBookMVC.Domain.Model.Recipe, RecipeForListVm>()
				.ForMember(q => q.Category, opt => opt.MapFrom(w => w.Category.Name));
		}
	}
}
