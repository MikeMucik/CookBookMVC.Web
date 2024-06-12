using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.ViewModels.Difficulty
{
    public class DifficultyForListVm : IMapFrom<CookBookMVC.Domain.Model.Difficulty>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DifficultyForListVm, CookBookMVC.Domain.Model.Difficulty>();
            profile.CreateMap<CookBookMVC.Domain.Model.Difficulty, DifficultyForListVm>();   //chyba pierwsze nie potrzebne
        }
    }
}
