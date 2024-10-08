namespace Teddy.Models;

public class Review
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public int Rating { get; set; } = 3;

    public Reviewer? Reviewer { get; set; }
    public Pokemon? Pokemon { get; set; }
}   