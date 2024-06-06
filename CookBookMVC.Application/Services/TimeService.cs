using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.ViewModels.Recipe;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.Services
{
	public class TimeService : ITimeService
	{
		private readonly ITimeRepository _timeRepo;
		private readonly IMapper _mapper;
		public TimeService(ITimeRepository timeRepo, IMapper mapper)
		{
			_timeRepo = timeRepo;
			_mapper = mapper;
		}

		public int AddTimeToRecipe(TimeForListVm time)
		{
			var timeAdd = _mapper.Map<Time>(time);
			var timeId = _timeRepo.AddTime(timeAdd);
				return timeId;
		}

		public ListTimeForListVm GetListTimeForList()
		{
			var times = _timeRepo.GetAllTimes();
			var timeVms = _mapper.Map<List<TimeForListVm>>(times);
			var timeList = new ListTimeForListVm
			{
				Times = timeVms,
			};
			return timeList;
		}

		public TimeForListVm GetTimeById(int id)
		{
			var timeSelected = _timeRepo.GetById(id);
			var timeVms = _mapper.Map<TimeForListVm>(timeSelected);
			return timeVms;
			
		}
	}
}
