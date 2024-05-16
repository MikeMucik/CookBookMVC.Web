using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;

namespace CookBookMVC.Application.ViewModels.User
{
	public class UserForListVm : IMapFrom<CookBookMVC.Domain.Model.User>
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public void Mapping(Profile profile) 
		{
			profile.CreateMap<CookBookMVC.Domain.Model.User, UserForListVm>()
			.ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
			.ForMember(d => d.Name, opt => opt.MapFrom(s => s.UserName));
		}
	
	}
}
