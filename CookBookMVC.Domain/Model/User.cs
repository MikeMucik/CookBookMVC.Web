using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookMVC.Domain.Model
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual UserInformation UserInformation { get; set; }
		public string Description { get; set; }
	}
}
