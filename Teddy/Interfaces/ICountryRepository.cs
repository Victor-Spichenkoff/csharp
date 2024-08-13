using Teddy.Models;

namespace Teddy.Interfaces;

public interface ICountryRepository
{
    ICollection<Country> GetCountries();
}
