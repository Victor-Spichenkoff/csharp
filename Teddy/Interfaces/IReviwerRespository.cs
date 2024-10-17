using Teddy.Models;

namespace Teddy.Interfaces;

public interface IReviewerRespository
{
    Reviewer GetReviewer(long id);
    ICollection<Reviewer> GetReviewers();
    ICollection<Review> GetReviewsByReviewer(long id);
    bool ReviewerExists(long id);

}
