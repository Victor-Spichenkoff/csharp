using Teddy.Models;

namespace Teddy.Interfaces;

public interface ICountryRepository
{
    ICollection<Country> GetCountries();
    Country CreateCountry(string name);

    String DeleteCountry(long id);
}
