using Teddy.Models;

namespace Teddy.Interfaces;

public interface ICategoryRepository
{
    ICollection<Category> GetCategories();


}
 