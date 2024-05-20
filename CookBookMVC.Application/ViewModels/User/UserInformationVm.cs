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
	public class UserInformationVm : IMapFrom<CookBookMVC.Domain.Model.User>
	{
		public int Id { get; set; }
		public string Name { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
		public string Email { get; set; }		
		public void Mapping(Profile profile)
		{
			profile.CreateMap<CookBookMVC.Domain.Model.User, UserInformationVm>()
				.ForMember(q => q.Name, opt => opt.MapFrom(w => w.UserInformation.FirstName + " " + w.UserInformation.LastName))
				.ForMember(q => q.Email, opt => opt.MapFrom(w => w.UserInformation.Email));
				
		}
	}
}
