using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Infrastructure;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CookBookMVC.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly Context _context;
		public UserRepository(Context context)
		{
			_context = context;
		}

        public int AddInformationToUser(UserInformation userInformation)
        {
            throw new NotImplementedException();
        }

        public int AddUser(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
			return user.Id;
		}

		public void DeleteUser(int userId)
		{
			var user = _context.Users.Find(userId);
			if (user != null)
			{
				_context.Users.Remove(user);
				_context.SaveChanges();
			}
		}

		public IQueryable<User> GetAllUsersActive()
		{
			return _context.Users.Where(u => u.IsActive);
		}

		public User GetUser(int userId)
		{
			var user = _context.Users
				.Include(u=>u.UserInformation)
				.FirstOrDefault(u => u.Id == userId);
			return user;
		}

		public int UpdateUser(User user)
		{
			throw new NotImplementedException();
		}
	}
}
