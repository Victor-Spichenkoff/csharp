using Teddy.Data;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Repositories;

public class PokemonRepository: IPokemonRepository
{
    //datacontext == meu conhtexto de db
    private readonly DataContext _context;
    public PokemonRepository(DataContext context)
    {
        _context = context;
    }

    public ICollection<Pokemon> GetPokemons()
    {
        //ToList, pois deve retornar um IColletion, conversão explicita
        return _context.Pokemon.OrderBy(p => p.Id).ToList();
    }
}
