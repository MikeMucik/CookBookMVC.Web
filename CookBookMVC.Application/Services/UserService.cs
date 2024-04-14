using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.Interfaces;

namespace CookBookMVC.Application.Services
{
	public class UserService : IUserService
	{
		public List<int> GetUsers()
		{
			var users = new List<int>();
			return users;
			
		}
	}
}
