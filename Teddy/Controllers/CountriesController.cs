using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teddy.Dto;
using Teddy.Interfaces;
using Teddy.Models;
using Teddy.Repositories;

namespace Teddy.Controllers;

[ApiController]
[Route("country")]
public class CountriesController(ICountryRepository cr, IMapper mapper) : Controller
{
    private readonly ICountryRepository _cr = cr;
    private readonly IMapper _mapper = mapper;


    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
    public IActionResult GetCountries()
    {
        var res = _mapper.Map<List<CountryDto>>(_cr.GetCountries());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(res);
    }


    [HttpGet("{countryId}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(404)]
    public IActionResult GetCountry(long countryId)
    {
        if (!_cr.CountryExistis(countryId))
            return NotFound();

        var country = _mapper.Map<CountryDto>(_cr.GetCountry(countryId));

        return Ok(country);
    }


    [HttpGet("/owners/{ownerId}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    [ProducesResponseType(400)]
    public IActionResult GetCountryByOwnerId(long ownerId)
    {
        var country = _mapper.Map<CountryDto>(_cr.GetCountryByOwner(ownerId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(country);
    }




    //[HttpGet("{ownerId}")]
    //[ProducesResponseType(200, Type = typeof(Country))]
    //[ProducesResponseType(404)]
    //public IActionResult GetCountryByOwner(long ownerId)
    //{
    //    var owner = _cr.GetCountryByOwner(ownerId);
    //    if (!ModelState.IsValid)
    //        return BadRequest(ModelState);

    //    return owner;
    //}


    [HttpPost]
    [ProducesResponseType(204)]
    public IActionResult CreateOneCountry([FromBody] CountryDto bodyCountry)
    {
        if (bodyCountry == null)
            return BadRequest("Insert a country");

            

        var existsCountry = _cr.GetCountries()
            .Where(c => c.Name.Trim().ToUpper() == bodyCountry.Name.Trim().ToUpper())
            .FirstOrDefault();

        if (existsCountry != null)
            return StatusCode(422, "Country already exists!");


        var mapperCountry = _mapper.Map<Country>(bodyCountry);
        var result = _cr.CreateCountry(mapperCountry);

        if(!result)
            return BadRequest("Something Went Wrong!");

        return Ok("Created Country!");
    }


    [HttpDelete("{countryId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteCountry(long countryId)
    {
        if (!_cr.CountryExistis(countryId))
            return StatusCode(404, "País não existe");

        var success = _cr.DeleteCountry(countryId);

        if (!success)
            return BadRequest("Algo deu errado");

        return NoContent();
    }

}
