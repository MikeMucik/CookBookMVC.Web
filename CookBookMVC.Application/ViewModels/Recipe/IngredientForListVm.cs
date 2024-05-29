﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.ViewModels.Recipe
{
	public class IngredientForListVm :IMapFrom<RecipeIngredient>
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }//??
		public string Unit { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<IngredientForListVm, RecipeIngredient>()
			.ForMember(i => i.Ingredient, opt => opt.MapFrom(q => new Ingredient
			{
				Id = q.Id,
				Name = q.Name,
				Unit = q.Unit,
			}));
		}
	}
}
