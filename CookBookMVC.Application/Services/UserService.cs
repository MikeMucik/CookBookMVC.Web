using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.ViewModels.User;
using CookBookMVC.Domain.Interface;

namespace CookBookMVC.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepo;
		public int AddUser(NewUserVm user)
		{
			throw new NotImplementedException();
		}

		public ListUserForListVm GetAllUsersForList()
		{
			var users = _userRepo.GetAllUsersActive();
			ListUserForListVm result = new ListUserForListVm();
			result.Users = new List<UserForListVm>();
            foreach (var user in users)
            {
                var userVm = new UserForListVm();
				{
					Id = user.Id;
					Name = user.Name;
				};
				result.Users.Add(userVm);
            }
			result.Count= result.Users.Count;
			return result;
        }

		public UserInformationVm GetUser(int userId)
		{
			throw new NotImplementedException();
		}

		//public List<int> GetUsers()
		//{
		//	var users = new List<int>();
		//	return users;
		//}
	}
}
