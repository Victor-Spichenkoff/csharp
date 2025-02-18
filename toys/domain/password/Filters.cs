namespace toys.password;

public class Filters
{
    private int _size;

    public int Size
    {
        get { return _size; }
        set
        {
            if(value < 4) _size = value;
            else if (value > 16) _size = 16;
            else _size = value;
        }
    }
     
    public bool onlyLowerCase = false;
    public bool onlyUpperCase = false;
    public bool onlyNumbers = false;
    public bool useSpecialChars = true;
}