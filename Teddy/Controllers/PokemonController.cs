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
    private readonly IOwnerRepository _ownerRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    //context seria adicionado do mesmo jeito, mas isso seria hardcoding
    public PokemonController(
        IPokemonRepository pokemonRepository,
        IMapper mapper,
        IOwnerRepository ownerRepository,
        ICategoryRepository categoryRepository
        )
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
        _ownerRepository = ownerRepository;
        _categoryRepository = categoryRepository;

    }


    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    public IActionResult GetPokemons()
    {
        //mapper == Passa o tipo de retono (uma lista de PokemonDto, ele converte para o Dto)
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
    public IActionResult GetPokemonRating(long pokeId)
    {
        if (!_pokemonRepository.PokemonExists(pokeId))
            return NotFound();

        var rating = _pokemonRepository.GetPokemonRating(pokeId);

        //verifica se está de acordo com o model e o parâmetro é certo
        if (!ModelState.IsValid)
            return BadRequest();

        return Ok(rating);
    }


    [HttpGet("/all")]
    public ICollection<Pokemon> GetAllPokemonsFulLData()
    {
        return _pokemonRepository.GetPokemons();
    }


    [HttpPost]
    [ProducesResponseType(204)]
    public IActionResult CreateOwner([FromQuery] long ownerId, [FromQuery] long categoryId, [FromBody] PokemonDto bodyPokemon)
    {
        if (bodyPokemon == null)
            return StatusCode(400, "Passe um Pokemon");


        var exists = _pokemonRepository.GetPokemons()
            .Where(o => o.Name.Trim().ToUpper() == bodyPokemon.Name.Trim().ToUpper() ||
                o.Id == bodyPokemon.Id)
            .FirstOrDefault();

        if (exists != null)
            return BadRequest("Already exists");


        var mappedPokemon = _mapper.Map<Pokemon>(bodyPokemon);

        var successCreated = _pokemonRepository.CreatePokemon(ownerId, categoryId, mappedPokemon);

        if (!successCreated)
            return BadRequest("Something went wrong");

        return Ok("Created!");
    }


    [HttpPut("/pokeId")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCategory(
            long pokeId, 
            [FromQuery] long ownerId, 
            [FromQuery] long categoryId, 
            [FromBody] PokemonDto bodyCat
        )
    {
        if (pokeId != bodyCat.Id)
            return BadRequest("Incontância nos dados");

        if (!_pokemonRepository.PokemonExists(pokeId))
            return NotFound("Não existe");


        var mappedPokemon = _mapper.Map<Pokemon>(bodyCat);

        var success = _pokemonRepository.UpdatePokemon(ownerId, categoryId, mappedPokemon);

        if (!success)
            BadRequest("Algo deu errado");


        return Ok("Updated");
    }
}
