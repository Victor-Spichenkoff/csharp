using System;


public class Aula50
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Dentro de aula 51.cs");

        if (args[0] != null)
        {
            Console.WriteLine(args[0]);
        }

        int count = 0;
        foreach(string entry in args)
        {
            count++;
            Console.Write($"Passagem {count}  ----  ");
            Console.WriteLine(entry);
        }
    }
}
