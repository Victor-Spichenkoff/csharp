using Teddy.Data;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Repositories;

public class ReviewRepository(DataContext context) : IReviewRepository
{
    //datacontext == meu conhtexto de db
    private readonly DataContext _context = context;

    public ICollection<Review> GetReviews()
    {
        //ToList, pois deve retornar um IColletion, conversão explicita
        return _context.Reviews.OrderBy(p => p.Id).ToList();
    }
}
