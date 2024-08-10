namespace Teddy.Models;

public class Country    
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;


    public ICollection<Owner>? Owners { get; set; }
}   