using PokemonReviewApp.Data;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public bool CategoryExists(int categoryId)
        {
            return _context.Categories.Any(c => c.Id == categoryId);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int catId)
        {
            return _context.Categories.Where(c => c.Id == catId).FirstOrDefault();
        }

        public ICollection<Pokemon> GetPokemonsByCategory(int catId)
        {
            return _context.PokemonCategories.Where(c => c.CategoryId == catId).Select(c => c.Pokemon).ToList();
        }
    }
}
