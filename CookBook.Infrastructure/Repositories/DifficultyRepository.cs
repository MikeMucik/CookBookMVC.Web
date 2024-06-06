using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Infrastructure;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Domain.Model;

namespace CookBookMVC.Infrastructure.Repositories
{
	public class DifficultyRepository : IDifficultyRepository
	{
		private readonly Context _context;
		public DifficultyRepository(Context context)
		{
			_context = context;
		}
		public int AddDiffuclty(Difficulty difficulty)
		{
			throw new NotImplementedException();
		}

		public void DeleteDifficulty(int difficultyId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Difficulty> GetAllDifficulties()
		{
			return _context.Difficulty.ToList();
		}
	}
}
