using System;
namespace Brincar;

class Utils
{
    public static string Input(string label)
    {
        Console.Write(label);
        string? res = Console.ReadLine();
        if (res == null)
            return Input(label);

        return res;
    }
}
