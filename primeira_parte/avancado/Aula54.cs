using System;
using System.Collections.Generic;

//dictionary

class Aula54
{
    public static void Main()
    {
        Dictionary <int, string> obj = new Dictionary<int, string>();
        obj.Add(1, "Campo 1");
        obj.Add(3, "Campo 3");
        obj.Add(4, "Campo 4");
        obj.Add(0, "Campo index 0");

        int size = obj.Count;

        Console.WriteLine("O tamanho é: " + size);
        //lacos
        foreach(var  linha in obj)
        {
            Console.WriteLine($"{linha.Key} -- {linha.Value}");
        }       
        
        
        foreach(string linha in obj.Values)
        {
            Console.WriteLine($"{linha}");
        }
    }
}
