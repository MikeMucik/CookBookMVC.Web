using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.ViewModels.Recipe;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Application.Services
{
	public class DifficultyService : IDifficultyService
	{
		private readonly IDifficultyRepository _difficultyRepo;
		private readonly IMapper _mapper;

		public DifficultyService(IDifficultyRepository difficultyRepo, IMapper mapper)
		{
			_difficultyRepo = difficultyRepo;
			_mapper = mapper;
		}

		public int AddDifficulty(DifficultyForListVm difficulty)
		{
			var difficultyAdd = _mapper.Map<Difficulty>(difficulty);
			var difficltyId = _difficultyRepo.AddDiffuclty(difficultyAdd);
			return difficltyId;
			
		}

		public void DeleteDifficulty(int difficultyId)
		{
			throw new NotImplementedException();
		}

		public ListDifficultyForListVm GetListDifficultyForList()
		{
			var difficulties = _difficultyRepo.GetAllDifficulties();
			var difficultyVms = _mapper.Map<List<DifficultyForListVm>>(difficulties);
			var difficultyList = new ListDifficultyForListVm
			{
				Difficulties = difficultyVms,
			};
			return difficultyList;

			
		}
	}
}
