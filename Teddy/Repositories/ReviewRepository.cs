using Microsoft.EntityFrameworkCore;
using Teddy.Data;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Repositories;

public class ReviewRepository(DataContext context) : IReviewRepository
{
    //datacontext == meu conhtexto de db
    private readonly DataContext _context = context;

    public bool CreateReview(Review review)
    {
        _context.Reviews.Add(review);

        return _context.SaveChanges() > 0;
    }

    public Review GetReview(long id)
    {
        return _context.Reviews.Where(r => r.Id == id).First();
    }

    public ICollection<Review> GetReviews()
    {
        //ToList, pois deve retornar um IColletion, conversão explicita
        return _context.Reviews.OrderBy(p => p.Id).ToList();
    }

    public ICollection<Review> GetReviewsOfAPokemon(long pokeId)
    {
        return [.. _context.Reviews.Where(r => r.Pokemon.Id == pokeId)];
    }

    public bool ReviewExists(long id)
    {
        return _context.Reviews.Any(r =>  r.Id == id);
    }
}
