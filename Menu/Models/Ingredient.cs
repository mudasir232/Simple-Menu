namespace Menu.Models
{
    public class Ingredient
    {
        public int Id { get; set; } // Primary key
        public string Name { get; set; } // Name of the ingredient

        // Navigation property
        public List<DishIngredeint>? DishIngredients { get; set; }
    }
}
