using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces
{
    public interface ICountryRepository
    {
        ICollection<Country> GetCountries();
        Country GetCountry(int countryId);

        ICollection<Owner> GetOwnerByCountry(int countryId);

        Country GetCountryByOwner(int countryId);
        bool CountryExists(int countryId);
    }
}
