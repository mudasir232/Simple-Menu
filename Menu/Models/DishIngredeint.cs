namespace Menu.Models
{
    public class DishIngredeint
    {
        public int DishId { get; set; } // Foreign key for Dish
        public Dish Dish { get; set; } // Navigation property for Dish

        public int IngredeintId { get; set; } // Foreign key for Ingredient
        public Ingredient Ingredeint { get; set; } // Navigation property for Ingredient
    }
}
