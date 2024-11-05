using Teddy.Data;
using Teddy.Interfaces;
using Teddy.Models;

namespace Teddy.Repositories;

public class CategoryRepository(DataContext context) : ICategoryRepository
{
    DataContext _context = context;

    public bool CategoryExists(long id)
    {
        //any = retorna true ou false, caso tenha ou não qualquer um que atenda a isso
        return _context.Categories.Any(c => c.Id == id); 
    }


    public ICollection<Category> GetCategories()
    {
        return _context.Categories.ToList();
    }

    public Category GetCategory(long id)
    {
        return (Category)_context.Categories.Where(c => c.Id == id).First();
    }

    public ICollection<Pokemon> GetPokemonByCategory(long categoryId)
    {
        return [.. _context.PokemonCategories
                .Where(pc => pc.CategoryId == categoryId)
                .Select(pc => pc.Pokemon)
            ];
    }

    public bool CreateCategory(Category category)
    {
         _context.Categories.Add(category);

        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }

    public bool UpdateCategory(Category category)
    {
        _context.Categories.Update(category);

        return Save();
    }

    public bool DeleteCategory(long id)
    {
        var categoryToDelete = new Category { Id = id };

        //ele precisa receber uma entidade "completa", não funciona só com o ID
        _context.Categories.Remove(categoryToDelete);

        return _context.SaveChanges() > 0;
    }
}
