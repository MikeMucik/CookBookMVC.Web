﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookMVC.Application.Interfaces
{
	public interface IUserService
	{
		List<int> GetUsers();
	}
}
