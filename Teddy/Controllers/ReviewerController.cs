using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Controllers;


[ApiController]
[Route("/reviewer")]
public class ReviewerController(IReviewerRespository rr, IMapper mapper) : Controller
{
    IReviewerRespository _rr = rr;
    IMapper _mapper = mapper;

    [HttpGet]
    public ICollection<Reviewer> GetReviewer()
    {
        var reviewers = _rr.GetReviewers();

        return reviewers;
    }


    [HttpGet("{reviewerId}")]
    [ProducesResponseType(typeof(Reviewer), 200)]
    [ProducesResponseType(404)]
    public IActionResult GetReviewer(long id)
    {
        if (!_rr.ReviewerExists(id))
            return NotFound();

        var reviewer = _rr.GetReviewer(id);

        return Ok(reviewer);
    }

    [HttpGet("{reviewerId}/reviews")]
    [ProducesResponseType(typeof(Reviewer), 200)]
    [ProducesResponseType(404)]
    public IActionResult GetReviewsOfAReviewer(long reviewerId)
    {
        if (!_rr.ReviewerExists(reviewerId))
            return NotFound();

        return Ok(_rr.GetReviewsByReviewer(reviewerId));
    }
}
