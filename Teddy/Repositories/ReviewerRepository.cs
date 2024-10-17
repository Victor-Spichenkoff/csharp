using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Teddy.Data;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Repositories;

public class ReviewerRepository(DataContext ctx) : IReviewerRespository
{
    DataContext _context = ctx;

    public Reviewer GetReviewer(long id)
    {
        return _context
            .Reviewers
            .Where(r => r.Id == id)
            .Include(r => r.Reviews)
            .First();
    }


    public ICollection<Reviewer> GetReviewers() =>
        [.. _context.Reviewers];


    public ICollection<Review> GetReviewsByReviewer(long id) =>
        _context.Reviews.Where(r => r.Reviewer.Id == id).ToList();


    public bool ReviewerExists(long id) =>
        _context.Reviewers.Any(r => r.Id == id);

}
