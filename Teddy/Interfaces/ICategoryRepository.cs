using Teddy.Models;

namespace Teddy.Interfaces;

public interface ICategoryRepository
{
    //pural
    ICollection<Category> GetCategories();
    //singular
    Category GetCategory(long id);
    
    ICollection<Pokemon> GetPokemonByCategory(long categoryId);

    bool CategoryExists(long id);

    // create
    bool CreateCategory(Category category);
    bool Save();
    //update
    bool UpdateCategory(Category category);
    //delete
    bool DeleteCategory(long id);
}
 