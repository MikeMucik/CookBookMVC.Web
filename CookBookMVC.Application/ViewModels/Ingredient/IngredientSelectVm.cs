using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;

namespace CookBookMVC.Application.ViewModels.Ingredient
{
    public class IngredientSelectVm :IMapFrom<Domain.Model.RecipeIngredient>
    {
       public int IngredientId {  get; set; }
        public int Quantity { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IngredientSelectVm, Domain.Model.RecipeIngredient>();
            profile.CreateMap<Domain.Model.RecipeIngredient,  IngredientSelectVm>();
        }
    }
}
