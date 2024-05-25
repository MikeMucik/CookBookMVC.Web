using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;

namespace CookBookMVC.Application.ViewModels.User
{
	public class NewUserVm :IMapFrom<CookBookMVC.Domain.Model.User>
	{
		public int Id { get; set; }
		public string FirstName { get; set; } //zmiana z Name
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string UserName { get; set; }
		public string? Descrption { get; set; }
		//public bool IsActive { get; set; }
		public void Mapping(Profile profile)
		{
			profile.CreateMap<UserForListVm, CookBookMVC.Domain.Model.User>();
			
		}
	}
}
