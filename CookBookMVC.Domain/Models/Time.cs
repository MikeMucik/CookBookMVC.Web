using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookMVC.Domain.Model
{
	public class Time
	{
		public int Id { get; set; }
		public int Amount { get; set; }
		public int Unit { get; set; }
		public virtual ICollection<Recipe> Recipes { get; set; }
	}
}
