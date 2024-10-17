using Teddy.Models;

namespace Teddy.Interfaces;

public interface ICountryRepository
{
    ICollection<Country> GetCountries();
    Country GetCountry(long id);
    Country CreateCountry(string name);
    Country GetCountryByOwner(long ownerId);
    ICollection<Owner> GetOwnersFromACountry(long countryId);
    bool CountryExistis(long id);
    bool CreateCountry(Country country);
}
