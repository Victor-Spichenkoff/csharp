using System;

namespace Inputs;

public class Input()
{
    public static string String(string label)
    {
        Console.Write(label);
        string? res = Console.ReadLine();
        if (res == null)
            return String(label);

        return res;
    }

/*

Retorna um número inteiro
*/
    public static int Int(string label)
    {
        Console.Write(label);
        string? res = Console.ReadLine();
        if (res == null)
            return Int(label);

        try
        {
            return int.Parse(res);
        }
        catch
        {
            Console.WriteLine("Não sabe contar?????????");
            return Int(label);
        }
    }
    
    public static double Double(string label)
    {
        Console.Write(label);
        string? res = Console.ReadLine();
        if (res == null)
            return Int(label);

        try
        {
            return double.Parse(res);
        }
        catch
        {
            Console.WriteLine("Não sabe contar?????????");
            return Int(label);
        }
    }
    
    /*
     * * Passar com o [s/n]
     */
    public static bool Bool(string label)
    {
        Console.Write(label);
        var res = Console.ReadLine();
        return res?.ToLower() == "s";
    }    
    
    /*
     * * Passar com o [y/n]
     */
    public static bool BoolEnglish(string label)
    {
        Console.Write(label);
        var res = Console.ReadLine();
        return res?.ToLower() == "y";
    }
}