using Microsoft.EntityFrameworkCore;
using Teddy.Data;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Repositories;

public class CountryRepository(DataContext context) : ICountryRepository
{
    private readonly DataContext _context = context;

    public ICollection<Country> GetCountries()
    {
        var countries = _context.Countries.OrderBy(c => c.Id).ToList();

        return countries;
    }

    public Country CreateCountry(string name)
    {
        var country = new Country { Name = name };
        var createdCountry = _context.Add(country);
        _context.SaveChanges();
        return country;
    }

    public String DeleteCountry(long id)
    {
        //_context.Countries.ExecuteDelete(c => c.id = id);

        return "Apadado";
    }
}
