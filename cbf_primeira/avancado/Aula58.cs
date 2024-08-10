using System;
using System.Collections.Generic;

class Aula58
{
    public static void Main(string[] args)
    {
        List<string> array = new List<string>();
        List<string> array2 = new List<string>();
        string[] array3 = new string[2];

        array.Add("Gol");
        array.Add("Omega");
        array.Add("Monza");
        array.Add("Aventador");

        foreach (string carro in array)
        {
            Console.WriteLine(carro);
        }

        array.CopyTo(1, array3, 0, 2);//pega a partir do 2° elemento, coloca no novon a partir do indece 0 dele e coloca 2 itens


        Console.WriteLine("\n\n Carros 2");

        foreach (string carro in array3)
        {
            Console.WriteLine(carro);
        }

        Console.WriteLine($"O index de CRETA é {array.IndexOf("CRETA")}");
    }
}