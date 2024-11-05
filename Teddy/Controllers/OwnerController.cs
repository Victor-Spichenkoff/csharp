using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teddy.Dto;
using Teddy.Interfaces;
using Teddy.Models;
using Teddy.Repositories;

namespace Teddy.Controllers;


[ApiController]
[Route("/owner")]
public class OwnerController(IOwnerRepository ownerRepo, IMapper mapper, ICountryRepository cr) : Controller
{
    private readonly IOwnerRepository _or = ownerRepo;
    private readonly IMapper _mapper = mapper;
    ICountryRepository _countryRepo = cr;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Owner>), 200)]
    public IActionResult GetAllOwners()
    {
        var owners = _mapper.Map<List<OwnerDto>>(_or.GetOwners());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(owners);
    }

    [HttpGet("{ownerId}")]
    [ProducesResponseType(typeof(Owner), 200)]
    [ProducesResponseType(404)]
    public IActionResult GetOwner(long ownerId)
    {
        if (!_or.OwnerExists(ownerId)) return NotFound();

        var owners = _mapper.Map<OwnerDto>(
                _or.GetOwner(ownerId)
            );

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(owners);
    }

    [HttpGet("{ownerId}/pokemon")]
    [ProducesResponseType(typeof(Owner), 200)]
    [ProducesResponseType(404)]
    public IActionResult GetPokemonByOwner(long ownerId)
    {
        if (!_or.OwnerExists(ownerId)) return BadRequest(ownerId);

        var owner = _mapper.Map<List<OwnerDto>>(_or.GetOwnerOfAPokemon(ownerId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(owner);
    }


    //testes only
    [HttpGet("all")]
    public ICollection<Owner> GetFullOwnersData()
    {
        return _or.GetOwners();
    }


    [HttpPost]
    [ProducesResponseType(204)]
    public IActionResult CreateOwner([FromBody] OwnerDto bodyOwner)
    {
        if (bodyOwner == null)
            return StatusCode(400, "Passe uma resposta");

        var exists = _or.GetOwners()
            .Where(o => o.Name.Trim().ToUpper() == bodyOwner.Name)
            .FirstOrDefault();

        if (exists != null)
            return BadRequest("Already exists");

        var mappedOwner = _mapper.Map<Owner>(bodyOwner);


        var success = _or.CreateOwner(mappedOwner);

        if (!success)
            return BadRequest("Something went wrong");

        return Ok("Created!");
    }
}