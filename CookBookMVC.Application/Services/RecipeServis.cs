using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Application.Interfaces;

namespace CookBookMVC.Application.Services
{
    public class RecipeServis : IRecipeServis
    {
        public List<int> GetAllRecipes()
        {
            var recipes = new List<int>();
            return recipes;
        }
    }
}
