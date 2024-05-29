using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;

namespace CookBookMVC.Application.ViewModels.Recipe
{
	public class NewCategoryVm: IMapFrom<CookBookMVC.Domain.Model.Category>
	{
		public int Id { get; set; }
		public string Name { get; set;}
		public void Mapping(Profile profile)
		{
			profile.CreateMap<NewCategoryVm, CookBookMVC.Domain.Model.Category>();
		}
	}
}
