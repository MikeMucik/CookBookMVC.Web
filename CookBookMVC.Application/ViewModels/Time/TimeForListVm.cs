using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Mapping;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.ViewModels.Time
{
    public class TimeForListVm : IMapFrom<CookBookMVC.Domain.Model.Time>
    {
        public int? Id { get; set; }
        public int? Amount { get; set; }//
        public string? Unit { get; set; }//
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TimeForListVm, CookBookMVC.Domain.Model.Time>();
            profile.CreateMap<CookBookMVC.Domain.Model.Time, TimeForListVm>();

        }
    }
}
