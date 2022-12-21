using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface IOwnerRepository
    {
        ICollection<Owner> GetOwners();
        Owner GetOwner(int ownerId);

        ICollection<Pokemon> GetPokemonsByOwner(int ownerId);

        ICollection<Owner> GetOwnersByPokemon(int pokeId);
        bool OwnerExist(int ownerId);
    }
}
