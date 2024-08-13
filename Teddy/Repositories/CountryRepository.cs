using Teddy.Data;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Repositories;

public class CountryRepository(DataContext context): ICountryRepository
{
    private readonly DataContext _context = context;

    public ICollection<Country> GetCountries()
    {
        var countries = _context.Countries.OrderBy(c => c.Id).ToList();

        return countries;
    }
}
