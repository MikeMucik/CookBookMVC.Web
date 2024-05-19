using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBookMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CookBook.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Difficulty> Difficulty { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredient { get; set; }//tabela pośrednia ale z dodatkiem quantity
        public DbSet<Time> Times { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInformation> UsersInformation { get; set; }
        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(u => u.UserInformation).WithOne(x => x.User)
                .HasForeignKey<UserInformation>(z => z.UserRef);

            builder.Entity<RecipeIngredient>()
                .HasKey(re => new { re.RecipeId, re.IngredientId });

            builder.Entity<RecipeIngredient>()
                .HasOne<Recipe>(re => re.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(re => re.RecipeId);

            builder.Entity<RecipeIngredient>()
                .HasOne<Ingredient>(re => re.Ingredient)
                .WithMany(s => s.RecipeIngredients)
                .HasForeignKey(re => re.IngredientId);
        }

    }
}
//builder.Entity<RecipeIngredient>()
//	.Property(rq => rq.Quantity)
//	.HasField("quantity"); 