using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.ViewModels.Ingredient
{
    public class IngredientNotQuantityForListVm : IMapFrom<Domain.Model.Ingredient>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<IngredientNotQuantityForListVm, Domain.Model.Ingredient>();
            profile.CreateMap<Domain.Model.Ingredient, IngredientNotQuantityForListVm>();
        }
    }
}
