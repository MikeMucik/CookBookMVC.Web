using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Infrastructure;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Infrastructure.Repositories
{

	public class TimeRepository : ITimeRepository
	{
		private readonly Context _context;
		public TimeRepository (Context context)
		{
			_context = context;
		}

		public int AddTime(Time time)
		{
			_context.Times.Add(time);
			_context.SaveChanges();
			return time.Id;
		}

		public IEnumerable<Time> GetAllTimes()
		{
			return _context.Times.ToList();
		}

		public Time GetById(int id)
		{			
			return _context.Times.Find(id);
		}
	}
}
