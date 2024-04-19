using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Domain.Interface
{
	public interface IUserRepository
	{
		IQueryable<User> GetAllUsersActive();
		void DeleteUser(int userId);
		int AddUser(User user);
		int UpdateUser(User user);
		User GetUser(int userId);
	}
}
