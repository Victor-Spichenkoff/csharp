using AutoMapper;
using AutoMapper.QueryableExtensions;
using Teddy.Data;
using Teddy.Dto;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Repositories;

public class PokemonRepository : IPokemonRepository
{
    //datacontext == meu conhtexto de db
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public PokemonRepository(DataContext context, IMapper m)
    {
        _context = context;
        _mapper = m;
    }

    public ICollection<Pokemon> GetPokemons()
    {
        //ToList, pois deve retornar um IColletion, conversão explicita
        return _context.Pokemon.OrderBy(p => p.Id).ToList();
    }

    public Pokemon GetPokemon(long id)
    {
        return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
    }

    public Pokemon GetPokemon(string name)
    {
        return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
    }

    public decimal GetPokemonRating(long pokeId)
    {
        var reviews = _context.Reviews.Where(r => r.Pokemon.Id == pokeId);

        if(reviews.Count() <= 0)
            return 0;

        return ((decimal)reviews.Sum(r => r.Rating) /reviews.Count());
    }

    public bool PokemonExists(long pokeId)
    {
        return _context.Pokemon.Any(p => p.Id == pokeId);
    }

    public ICollection<PokemonDto> GetDtoPokemons()
    {
        return _context.Pokemon
            .ProjectTo<PokemonDto>(_mapper.ConfigurationProvider)
            .ToList();
    }


    public bool CreatePokemon(long OwnerId, long categoryId, Pokemon pokemon)
    {
        //pegar a entidade completa
        var pokemonOwnerEntity = _context.Owners.Where(o => o.Id == OwnerId).FirstOrDefault();
        var categoryEnitity = _context.Categories.Where(c => c.Id == categoryId).FirstOrDefault();

        // pokemon owner == entidade de relacionamento do pokemon
        var pokemonOwner = new PokemonOwner()
        {
            //Owner = pokemonOwnerEntity,
            OwnerId = OwnerId,//auto mapeado pelo EF
            Pokemon = pokemon
        };

        _context.PokemonOwners.Add(pokemonOwner);

        var pokemonCategory = new PokemonCategory()
        { 
            Category = categoryEnitity,
            Pokemon = pokemon
        };

        //esse jeito é mais simplificado
        _context.Add(pokemonCategory);


        _context.Pokemon.Add(pokemon);

        return _context.SaveChanges() > 0; 
    }

    public bool UpdatePokemon(long ownerId, long categoryId, Pokemon pokemon)
    {
        _context.Update(pokemon);

        return _context.SaveChanges() > 0; 
    }
}
