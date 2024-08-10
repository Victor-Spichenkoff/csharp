namespace Teddy.Models;

public class Pokemon
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }


    //relaçãp
    public ICollection<Review>? Reviews { get; set; } 
    
    //n-n
    public ICollection<PokemonOwner>? PokemonOwners { get; set; }
    public ICollection<PokemonCategory>? PokemonCategories { get; set; } 

}