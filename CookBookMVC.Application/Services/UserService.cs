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

		public void DeleteUser(int userId)
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
				var userVm = new UserForListVm()
				{
					Id = user.Id,
					Name = user.UserName
				};
				result.Users.Add(userVm);
			}
			result.Count = result.Users.Count;
			return result;
		}

		public UserInformationVm GetUser(int userId)
		{
			var user = _userRepo.GetUser(userId);
			var userVm = new UserInformationVm();
			userVm.Id = user.Id;

			userVm.Description = user.Description;
			var userInfo = user.UserInformation;
			userVm.Name = userInfo.FirstName + " " + userInfo.LastName;
			userVm.Email = userInfo.Email;
			userVm.UserName = user.UserName;
			return userVm;

		}
	}
}
