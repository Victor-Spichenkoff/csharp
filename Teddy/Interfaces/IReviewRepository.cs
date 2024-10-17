using Teddy.Models;

namespace Teddy.Interfaces;

public interface IReviewRepository
{
    ICollection<Review> GetReviews();
    Review GetReview(long id);
    ICollection<Review> GetReviewsOfAPokemon(long pokeId);
    bool ReviewExists(long id);
}
