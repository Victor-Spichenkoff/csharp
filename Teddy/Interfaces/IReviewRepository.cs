using Teddy.Models;

namespace Teddy.Interfaces;

public interface IReviewRepository
{
    ICollection<Review> GetReviews();
}
