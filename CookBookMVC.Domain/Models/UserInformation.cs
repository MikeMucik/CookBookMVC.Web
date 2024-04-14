using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookMVC.Domain.Model
{
	public class UserInformation
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public int UserRef {  get; set; } // dlaczego używamy UserRef a nie UserId ?
		public User User { get; set; }
	}
}
