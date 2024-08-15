using Teddy.Dto;
using Teddy.Models;

namespace Teddy.Interfaces;

public interface IPokemonRepository
{
    ICollection<Pokemon> GetPokemons();
    Pokemon GetPokemon(long id); 
    Pokemon GetPokemon(string name);
    decimal GetPokemonRating(long pokeId);
    bool PokemonExists(long pokeId);
    ICollection<PokemonDto> GetDtoPokemons();
}
