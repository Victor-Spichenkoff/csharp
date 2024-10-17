using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teddy.Interfaces;
using Teddy.Models;
using Teddy.Repositories;
using Teddy.Dto;

namespace Teddy.Controllers;

[ApiController]
[Route("review")]
public class ReviewsController(IReviewRepository reviewRespository, IMapper mapper) : Controller
{
    private readonly IReviewRepository _reviewRepository = reviewRespository;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
    public IActionResult GetReviews()
    {
        var reviews = _mapper.Map<List<Review>>(
                _reviewRepository.GetReviews()
            );

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        return Ok(reviews);
    }


    [HttpGet("{reviewId}")]
    [ProducesResponseType(typeof(Review), 200)]
    [ProducesResponseType(404)]
    public IActionResult GetReviewById(long reviewId)
    {
        if (!_reviewRepository.ReviewExists(reviewId))
            return NotFound();

        var review = _mapper.Map<ReviewDto>(
            _reviewRepository.GetReview(reviewId));

        return Ok(review);
    }


    [HttpGet("pokemon/{pokeId}")]
    [ProducesResponseType(typeof(ICollection<Review>), 200)]
    public IActionResult GetReviewFromPokemon(long pokeId)
    {
        var reviews = _mapper.Map<List<ReviewDto>>(
                _reviewRepository.GetReviewsOfAPokemon(pokeId)
            );

        if (!ModelState.IsValid) return BadRequest(ModelState);

        return Ok(reviews);
    }
}

