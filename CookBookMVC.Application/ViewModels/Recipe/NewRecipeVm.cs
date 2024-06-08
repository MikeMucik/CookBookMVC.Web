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
        public int CategoryId { get; set; } //
        public int AmountOfIngredients { get; set; }
        public List<IngredientForListVm> Ingredients { get; set; } = new List<IngredientForListVm>(); //? to do zmiany by wybierać składnik z listy bądź dodać nowy
        public int DifficultyId { get; set; }
        public int? TimeId { get; set; }
        public int? TimeAmount { get; set; }
        public string? TimeUnit { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewRecipeVm, CookBookMVC.Domain.Model.Recipe>()
                .ForMember(r=> r.TimeId, opt=> opt.MapFrom(t=>t.TimeId))
                .ForMember(r => r.Time, opt => opt.MapFrom(t => 
                t.TimeId.HasValue
                ? null 
                :new Time
                {
                    Amount = (int)t.TimeAmount,
                    Unit = t.TimeUnit,
                }))
                .ForMember(r => r.CategoryId, opt => opt.MapFrom(w => w.CategoryId))
                .ForMember(r => r.DifficultyId, opt => opt.MapFrom(e => e.DifficultyId))
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
                }).ToList()));
        }
    }
}
