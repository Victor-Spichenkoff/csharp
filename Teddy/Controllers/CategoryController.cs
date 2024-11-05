using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Teddy.Dto;
using Teddy.Interfaces;
using Teddy.Models;
using Teddy.Repositories;

namespace Teddy.Controllers;

[Route("category")]
[ApiController]
public class CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    : Controller
{
    private ICategoryRepository _cr = categoryRepository;
    private IMapper _mapper = mapper;


    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
    public IActionResult GetCategories()
    {
        var res = _mapper.Map<List<CategoryDto>>(_cr.GetCategories());

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(res);
    }


    [HttpGet("{catId}")]
    [ProducesResponseType(200, Type = typeof(Category))]
    [ProducesResponseType(404)]
    public IActionResult GetOnePokemonFiltered(long catId)
    {
        if (!_cr.CategoryExists(catId))
            return NotFound("Cound't find pokemon");

        var pokemon = _mapper.Map<Category>(_cr.GetCategory(catId));

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemon);
    }


    [HttpGet("pokemon/{categoryId}")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
    [ProducesResponseType(404)]
    public IActionResult GetPokemonByCategoryId(long categoryId)
    {
        var pokemons = _mapper.Map<List<PokemonDto>>(_cr.GetPokemonByCategory(categoryId));

        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(pokemons);
    }


    [HttpPost]
    [ProducesResponseType(204)]
    public IActionResult CreateCategory([FromBody] CategoryDto bodyCat)
    {
        // validações
        if (bodyCat == null) return BadRequest();

        
        var existsCategory = _cr.GetCategories()
            .Where(c => c.Name.Trim().ToUpper() == bodyCat.Name.Trim().ToUpper())
            .FirstOrDefault();
        
        if (existsCategory != null)// repetido (nome)
        {
            ModelState.AddModelError("error", "Category already exists");
            return StatusCode(422, "ModelState");
        }


        var categoryMap = _mapper.Map<Category>(bodyCat);

        var result = _cr.CreateCategory(categoryMap);

        if(!result)
        {
            ModelState.AddModelError("", "Error on creation");
            return StatusCode(500, ModelState);
        }
    
        return Ok("Created!");
    }


    [HttpPut("/categoryId")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult UpdateCategory(long categoryId, [FromBody] CategoryDto bodyCat)
    {
        if (categoryId != bodyCat.Id)
            return BadRequest("Incontância nos dados");

        if (!_cr.CategoryExists(categoryId))
            return NotFound("Não existe");


        var mappedCategory = _mapper.Map<Category>(bodyCat);

        var success = _cr.UpdateCategory(mappedCategory);

        if (!success)
            BadRequest("Algo deu errado");


        return Ok("Updated");
    }



    [HttpDelete("{categoryId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteCategory(long categoryId)
    {
        //lembrar que podem existir relacionamntos que dependem dela, verificar isso
        if (!_cr.CategoryExists(categoryId))
            return StatusCode(404, "Categoria inexistente");

        var success = _cr.DeleteCategory(categoryId);

        if (!success)
            return BadRequest("Erro ao salvar");

        return NoContent();
    }
}
