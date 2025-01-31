using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Menu.Data; // Namespace for the context
using Menu.Models; // Namespace for the models
using System.Threading.Tasks;

namespace Menu.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuContext _context;

        public MenuController(MenuContext context)
        {
            _context = context;
        }

        // Display the list of all dishes
        public async Task<IActionResult> Index()
        {
            var dishes = await _context.Dishes.ToListAsync();
            return View(dishes);
        }

        // Display details of a specific dish by ID
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Dish ID is required."); // Returns a 400 Bad Request if the ID is null
            }

            var dish = await _context.Dishes
                .Include(di => di.DishIngredients)
                .ThenInclude(di => di.Ingredeint) // Ensure "Ingredient" property name matches the model
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dish == null)
            {
                return NotFound($"No dish found with ID = {id}."); // Improved error message
            }

            return View(dish);
        }

        // Search functionality
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction(nameof(Index)); // Redirect to Index if query is empty
            }

            var results = await _context.Dishes
                .Where(d => EF.Functions.Like(d.Name, $"%{query}%")) // Case-insensitive SQL search
                .ToListAsync();

            return View("Index", results); // Reuses the Index view to display results
        }
    }
}

