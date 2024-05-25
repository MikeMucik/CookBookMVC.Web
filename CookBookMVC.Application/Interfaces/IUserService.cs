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
		int AddUser(NewUserVm user);

		void DeleteUser(int userId);

		ListUserForListVm GetAllUsersForList(int pageSize, int pageNo, string searchString);
		
		UserInformationVm GetUser(int userId);




		//List<int> GetUsers();
	}
}
