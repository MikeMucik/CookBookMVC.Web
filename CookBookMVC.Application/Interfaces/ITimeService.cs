using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.ViewModels.Recipe;

namespace CookBookMVC.Application.Interfaces
{
	public interface ITimeService
	{
		TimeForListVm GetTimeById (int id);
		int AddTimeToRecipe (TimeForListVm time);
		ListTimeForListVm GetListTimeForList();
	}
}
