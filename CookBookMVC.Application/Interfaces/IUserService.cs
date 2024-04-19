using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.ViewModels.User;

namespace CookBookMVC.Application.Interfaces
{
	public interface IUserService
	{
		ListUserForListVm GetAllUsersForList();
		int AddUser(NewUserVm user);
		UserInformationVm GetUser(int userId);


		//List<int> GetUsers();
	}
}
