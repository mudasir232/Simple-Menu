using Microsoft.EntityFrameworkCore;
using Menu.Models;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredeints { get; set; }
        public DbSet<DishIngredeint> DishIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite key for DishIngredeint
            modelBuilder.Entity<DishIngredeint>().HasKey(di => new { di.DishId, di.IngredeintId });

            // Relationship between Dish and DishIngredeint
            modelBuilder.Entity<DishIngredeint>()
                .HasOne(di => di.Dish)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);

            // Relationship between Ingredient and DishIngredeint
            modelBuilder.Entity<DishIngredeint>()
                .HasOne(di => di.Ingredeint)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredeintId);

            // Seed data for Dish
            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Burger", Price = 5.99, ImageUrl = "https://cdn.pixabay.com/photo/2022/07/15/18/16/beef-burger-7323692_640.jpg" }
            );

            // Seed data for Ingredient
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomato Sauce" },
                new Ingredient { Id = 2, Name = "Cheese" },
                new Ingredient { Id = 3, Name = "Bun" },
                new Ingredient { Id = 4, Name = "Beef" }
            );

            // Seed data for DishIngredeint
            modelBuilder.Entity<DishIngredeint>().HasData(
                new DishIngredeint { DishId = 1, IngredeintId = 1 },
                new DishIngredeint { DishId = 1, IngredeintId = 2 },
                new DishIngredeint { DishId = 1, IngredeintId = 3 },
                new DishIngredeint { DishId = 1, IngredeintId = 4 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
