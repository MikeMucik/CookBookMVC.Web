using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.Interfaces;
using CookBookMVC.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CookBookMVC.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IRecipeService, RecipeService>();
			services.AddTransient<IDifficultyService, DifficultyService>();
			services.AddTransient<ICategoryService, CategoryService>();
			services.AddTransient<ITimeService, TimeService>();
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			
			return services;
		}
	}
}
