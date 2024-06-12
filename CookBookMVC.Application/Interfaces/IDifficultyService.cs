using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.ViewModels.Difficulty;

namespace CookBookMVC.Application.Interfaces
{
    public interface IDifficultyService
	{
		int AddDifficulty(DifficultyForListVm difficulty);
		void DeleteDifficulty(int difficultyId);
		ListDifficultyForListVm GetListDifficultyForList();//
	}
}
