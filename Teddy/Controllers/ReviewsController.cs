using Microsoft.AspNetCore.Mvc;
using Teddy.Interfaces;
using Teddy.Models;
using Teddy.Repositories;

namespace Teddy.Controllers;

[ApiController]
[Route("review")]
public class ReviewsController(IReviewRepository pokemonRepository) : Controller
{
    private readonly IReviewRepository _reviewRepository = pokemonRepository;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
    public IActionResult GetReviews()
    {
        var reviews = _reviewRepository.GetReviews();

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(reviews);
    }

}

