namespace Teddy.Models;

public class Owner
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Gym { get; set; } = string.Empty;


    public Country? Country { get; set; }


    public ICollection<PokemonOwner>? PokemonOwners { get; set; }
}   