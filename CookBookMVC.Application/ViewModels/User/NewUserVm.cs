using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.ViewModels.User
{
	public class NewUserVm :IMapFrom<CookBookMVC.Domain.Model.User>
	{
		public int Id { get; set; }	
		
		public string UserName { get; set; }
		public string Description { get; set; }
		public bool IsActive { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public void Mapping(Profile profile)
		{
			profile.CreateMap<NewUserVm, CookBookMVC.Domain.Model.User>()
				.ForMember(u => u.UserInformation, opt => opt.MapFrom(s=> new UserInformation
				{
					FirstName = s.FirstName,
					LastName = s.LastName,
					Email = s.Email,
					Password = s.Password,
			})); 
				
		}
	}
}
