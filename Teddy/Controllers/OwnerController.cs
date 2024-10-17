using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teddy.Dto;
using Teddy.Interfaces;
using Teddy.Models;
using Teddy.Repositories;

namespace Teddy.Controllers;


[ApiController]
[Route("/owner")]
public class OwnerController(IOwnerRepository ownerRepo, IMapper mapper) : Controller
{
    private readonly IOwnerRepository _or = ownerRepo;
    private readonly IMapper _mapper = mapper;

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
}
