using Microsoft.AspNetCore.Mvc;
using Teddy.Interfaces;
using Teddy.Models;
using Teddy.Repositories;

namespace Teddy.Controllers;

[ApiController]
[Route("country")]
public class CountriesController(ICountryRepository cr) : Controller
{
    private readonly ICountryRepository _cr = cr;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
    public IActionResult GetCountries()
    {
        var res = _cr.GetCountries();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(res);
    }
}
