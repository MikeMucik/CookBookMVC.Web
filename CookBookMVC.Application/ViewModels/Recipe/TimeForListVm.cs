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
	public class TimeForListVm :IMapFrom<Time>
	{
		public int Id { get; set; }
		public int Amount { get; set; }//
		public string Unit { get; set; }//
		public void Mapping(Profile profile)
		{
			profile.CreateMap<TimeForListVm, Time>();
			profile.CreateMap<Time, TimeForListVm>();

		}
	}
}
