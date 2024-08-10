namespace Teddy.Models;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;


    public ICollection<PokemonCategory>? PokemonCategories { get; set; }
}   