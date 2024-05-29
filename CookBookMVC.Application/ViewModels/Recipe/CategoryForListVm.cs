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
	public class CategoryForListVm :IMapFrom<Category>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public void Mapping(Profile profile)
		{
			profile.CreateMap<CategoryForListVm, Category>();
			profile.CreateMap<Category, CategoryForListVm>();	//chyba jedno nie potrzebne
		}
	}
}
