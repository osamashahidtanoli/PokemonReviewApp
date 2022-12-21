using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int catId);
        ICollection<Pokemon> GetPokemonsByCategory(int catId);

        bool CategoryExists(int categoryId);
    }
}
