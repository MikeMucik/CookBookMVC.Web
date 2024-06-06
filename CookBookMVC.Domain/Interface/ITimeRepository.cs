using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Domain.Interface
{
	public interface ITimeRepository
	{
		int AddTime (Time time);
		IEnumerable<Time> GetAllTimes();
		Time GetById (int id);
	}
}
