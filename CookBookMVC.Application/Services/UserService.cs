using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.ViewModels.User;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepo;
		private readonly IMapper _mapper;

		public UserService(IUserRepository userRepo, IMapper mapper)
		{
			_userRepo = userRepo;
			_mapper = mapper;
		}

		public int AddUser(NewUserVm user)
		{
			var userAdd = _mapper.Map<User>(user);
			var id = _userRepo.AddUser(userAdd);
			return id;
		}

		public void DeleteUser(int userId)
		{
			throw new NotImplementedException();
		}

		public ListUserForListVm GetAllUsersForList(int pageSize, int pageNo, string searchString)
		{
			var users = _userRepo.GetAllUsersActive()
				.Where(p => p.UserName.StartsWith(searchString))
				.ProjectTo<UserForListVm>(_mapper.ConfigurationProvider)
				.ToList();
			var usersToShow = users
				.Skip(pageSize * (pageNo - 1))
				.Take(pageSize)
				.ToList();
			var userList = new ListUserForListVm()
			{
				PageSize = pageSize,
				CurrentPage = pageNo,
				SearchString = searchString, 
				Users = usersToShow,
				Count = users.Count
			};
			return userList;
			//ListUserForListVm result = new ListUserForListVm();
			//result.Users = new List<UserForListVm>();
			//foreach (var user in users)
			//{
			//	var userVm = new UserForListVm()
			//	{
			//		Id = user.Id,
			//		Name = user.UserName
			//	};
			//	result.Users.Add(userVm);
			//}
			//result.Count = result.Users.Count;
			//return result;
		}

		public UserInformationVm GetUser(int userId)
		{
			var user = _userRepo.GetUser(userId);
			if (user == null)
			{
				throw new Exception("User not found");
			}
			var userVm = _mapper.Map<UserInformationVm>(user);
			return userVm;
			//var userVm = new UserInformationVm();
			//userVm.Id = user.Id;

			//userVm.Description = user.Description;
			//var userInfo = user.UserInformation;
			//userVm.Name = userInfo.FirstName + " " + userInfo.LastName;
			//userVm.Email = userInfo.Email;
			//userVm.UserName = user.UserName;
			//return userVm;

		}
	}
}
