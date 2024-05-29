using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.ViewModels.Recipe
{
    public class NewRecipeVm : IMapFrom<CookBookMVC.Domain.Model.Recipe>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; } //
        public int AmountOfIngredients { get; set; }
        public List<IngredientForListVm> Ingredients { get; set; } = new List<IngredientForListVm>(); //?
        public string Difficulty { get; set; }
        public int TimeAmount { get; set; }
        public string TimeUnit { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewRecipeVm, CookBookMVC.Domain.Model.Recipe>()
                .ForMember(r => r.Time, opt => opt.MapFrom(q => new Time
                {
                    Amount = q.TimeAmount,
                    Unit = q.TimeUnit,
                }))
                .ForMember(r => r.Category, opt => opt.MapFrom(w => new Category
                {
                    Name = w.Category,
                }))
                .ForMember(r => r.Difficulty, opt => opt.MapFrom(e => new Difficulty
                {
                    Name = e.Name,
                }))
                .ForMember(r => r.RecipeIngredient, opt => opt.MapFrom(vm => vm.Ingredients.Select(i => new RecipeIngredient
                {
                    IngredientId = i.Id,
                    Quantity = i.Quantity,
                    Ingredient = new Ingredient
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Unit = i.Unit
                    }
                }).ToList()));//
        }
    }
}
