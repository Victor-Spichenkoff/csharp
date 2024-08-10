namespace Teddy.Models;

public class Reviewer
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;


    public ICollection<Review>? Reviews { get; set; }
}   