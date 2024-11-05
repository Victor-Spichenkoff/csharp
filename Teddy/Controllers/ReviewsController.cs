using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teddy.Interfaces;
using Teddy.Models;
using Teddy.Repositories;
using Teddy.Dto;

namespace Teddy.Controllers;

[ApiController]
[Route("review")]
public class ReviewsController(
        IReviewRepository reviewRespository,
        IMapper mapper,
        IPokemonRepository pokemonRepository,
        IReviewerRespository reviewerRespository  
    ) : Controller
{
    private readonly IReviewRepository _reviewRepository = reviewRespository;
    private readonly IMapper _mapper = mapper;
    IPokemonRepository _pokemonRepository = pokemonRepository;
    IReviewerRespository _reviewerRespository = reviewerRespository;

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


    [HttpPost]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    public IActionResult CreateOwner([FromQuery] long reviewerId, [FromQuery] long pokeId, [FromBody] ReviewDto bodyReview)
    {
        if (bodyReview == null)
            return StatusCode(400, "Passe uma review");

        var exists = _reviewRepository.GetReviews()
            .Where(o => o.Title.Trim().ToUpper() == bodyReview.Title.ToUpper())
            .FirstOrDefault();

        if (exists != null)
            return BadRequest("Already exists");

        var mappedReview = _mapper.Map<Review>(bodyReview);

        mappedReview.Pokemon = _pokemonRepository.GetPokemon(pokeId);
        mappedReview.Reviewer = _reviewerRespository.GetReviewer(reviewerId);

        var success = _reviewRepository.CreateReview(mappedReview);

        if (!success)
            return BadRequest("Something went wrong");

        return Ok("Created!");
    }
}

