using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Teddy.Data;
using Teddy.Dto;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Repositories;

public class CountryRepository(DataContext context, IMapper m) : ICountryRepository
{
    private readonly DataContext _context = context;
    private readonly IMapper _mapper = m;

    public ICollection<Country> GetCountries()
    {
        var countries = _context.Countries.ToList();

        return countries;
    }

    public Country CreateCountry(string name)
    {
        var country = new Country { Name = name };
        var createdCountry = _context.Add(country);
        _context.SaveChanges();
        return country;
    }


    public Country GetCountry(long id)
    {
        return _context.Countries
            .Where(c => c.Id == id).
            First();
    }


    public Country GetCountryByOwner(long ownerId)
    {
        return _context.Owners
            .Where(o => o.Id == ownerId)
            .Select(c => c.Country)
            .First();
    }

    public ICollection<Owner> GetOwnersFromACountry(long countryId)
    {
        return _context.Owners
            .Where(o => o.Country.Id == countryId)
            .ToList();
    }


    public bool CountryExistis(long id)
    {
        return _context.Countries.Any(c => c.Id == id);
    }

    public bool CreateCountry(Country country)
    {
        _context.Countries.Add(country);

        return _context.SaveChanges() > 0;
    }
}
