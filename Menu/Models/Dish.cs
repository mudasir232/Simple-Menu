
namespace Menu.Models
{
    public class Dish
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; } // Name of the dish
        public double Price { get; set; } // Price of the dish
        public string ImageUrl { get; set; } // Image URL

        // Navigation property
        public ICollection<DishIngredeint>? DishIngredients { get; set; }
    }
}
