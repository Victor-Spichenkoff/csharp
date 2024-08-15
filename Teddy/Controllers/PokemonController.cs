using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teddy.Interfaces;
using Teddy.Models;
using Teddy.Repositories;
using Teddy.Dto;

namespace Teddy.Controllers;

[ApiController]
[Route("pokemon")]
public class PokemonController: Controller
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IMapper _mapper;
    //context seria adicionado do mesmo jeito, mas isso seria hardcoding
    public PokemonController(
        IPokemonRepository pokemonRepository,
        IMapper mapper
        )
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }


    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetPokemons()
    {
        //mapper == Passa o tipo de retono (uma lista de POkemonDto, ele converte para o Dto)
        //var pokemons = _mapper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
        var pokemons = _pokemonRepository.GetDtoPokemons();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemons);
    }


    //meu proprio teste
    [HttpGet("rating/1")]
    [ProducesResponseType(200, Type = typeof(decimal))]
    public IActionResult GetRating()
    {
        var pokemonsRating = _pokemonRepository.GetPokemonRating(1);

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemonsRating);
    }


    [HttpGet("{pokeId}")]
    [ProducesResponseType(200, Type = typeof (Pokemon))]
    [ProducesResponseType(404)]
    public IActionResult GetOnePokemonFiltered(long pokeId)
    {
        if (!_pokemonRepository.PokemonExists(pokeId))
            return NotFound("Cound't find pokemon");

        var pokemon = _mapper.Map<PokemonDto>(_pokemonRepository.GetPokemon(pokeId));

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemon);
    }


    [HttpGet("{pokeId}/rating")]
    [ProducesResponseType(200, Type = typeof(decimal))]
    [ProducesResponseType(404)]
    public IActionResult GetPokemonrating(long pokeId)
    {
        if (!_pokemonRepository.PokemonExists(pokeId))
            return NotFound();

        var rating = _pokemonRepository.GetPokemonRating(pokeId);

        //verifica se está de arcordo com o model e o parametro é certo
        if (!ModelState.IsValid)
            return BadRequest();

        return Ok(rating);
    }
}
