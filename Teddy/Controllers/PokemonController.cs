using Microsoft.AspNetCore.Mvc;
using Teddy.Interfaces;
using Teddy.Models;
using Teddy.Repositories;

namespace Teddy.Controllers;

[ApiController]
[Route("pokemon")]
public class PokemonController: Controller
{
    private readonly IPokemonRepository _pokemonRepository;
    //context seria adicionado do mesmo jeito, mas isso seria hardcoding
    public PokemonController(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetPokemons()
    {
        var pokemons = _pokemonRepository.GetPokemons();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemons);
    }

}
