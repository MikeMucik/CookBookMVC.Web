using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Domain.Interface
{
	public interface IDifficultyRepository
	{
		int AddDiffuclty(Difficulty difficulty);
		void DeleteDifficulty(int difficultyId);
		IEnumerable<Difficulty> GetAllDifficulties();
	}
}
