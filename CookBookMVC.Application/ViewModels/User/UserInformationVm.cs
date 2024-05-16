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
	public class UserInformationVm : IMapFrom<UserInformation>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public void Mapping(Profile profile)
		{
			profile.CreateMap<UserInformation, UserInformationVm>()
				.ForMember(q => q.Name, opt => opt.MapFrom(w => w.FirstName + " " + w.LastName))
				.ForMember(q=>q.Id, opt=>opt.MapFrom(w=>w.User.Id))
				.ForMember(q => q.UserName, opt => opt.MapFrom(w => w.User.UserName));
		}
	}
}
