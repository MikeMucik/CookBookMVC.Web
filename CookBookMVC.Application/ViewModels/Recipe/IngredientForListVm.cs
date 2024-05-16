﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookMVC.Application.ViewModels.Recipe
{
	public class IngredientForListVm
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }//??
		public string Unit { get; set; }
	}
}
