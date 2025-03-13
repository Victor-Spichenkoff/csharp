namespace toys.utils;

public class JustBreak: Exception
{
    public JustBreak(string message) : base(message) { }
}