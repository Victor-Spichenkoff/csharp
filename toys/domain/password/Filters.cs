namespace toys.password;

public class Filters
{
    private int _size;

    public int Size
    {
        get { return _size; }
        set
        {
            if (value <= 2) _size = 2;
            else if (value > 32) _size = 32;
            else _size = value;
        }
    }
     
    public bool onlyLowerCase = false;
    public bool onlyUpperCase = false;
    public bool onlyNumbers = false;
    public bool useSpecialChars = true;
}