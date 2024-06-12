using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Infrastructure.Repositories;
using CookBookMVC.Domain.Interface;
using CookBookMVC.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CookBookMVC.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IRecipeRepository, RecipeRepository>();
			services.AddTransient<IDifficultyRepository, DifficultyRepository>();
			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<ITimeRepository, TimeRepository>();
			services.AddTransient<IIngredientRepository, IngredientRepository>();
			return services;
		}

	}
}
