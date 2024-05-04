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
		int AddUser(User user);

		void DeleteUser(int userId);

		IQueryable<User> GetAllUsersActive();

		User GetUser(int userId);

		int UpdateUser(User user);
	}
}
