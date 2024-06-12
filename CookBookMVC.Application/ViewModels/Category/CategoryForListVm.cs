using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.ViewModels.Category
{
    public class CategoryForListVm : IMapFrom<CookBookMVC.Domain.Model.Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CategoryForListVm, CookBookMVC.Domain.Model.Category>();
            profile.CreateMap<CookBookMVC.Domain.Model.Category, CategoryForListVm>();   //chyba jedno nie potrzebne
        }
    }
}
