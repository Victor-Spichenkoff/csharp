namespace toys.utils;

public class MyError: Exception
{
    public string Label = "=============================== APPLICATION ERROR ===============================";
    public MyError(string msg, string? label = null) : base(msg)
    {
        if (!string.IsNullOrEmpty(label))
            Label = label;
    }
    
    public bool IsMyError() => true;
}