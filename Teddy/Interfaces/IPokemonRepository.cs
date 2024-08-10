using Teddy.Models;

namespace Teddy.Interfaces;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemons();
}
