using System;
using System.Collections.Generic;
//csc -out:dist/Aula56.exe Aula56.cs && cd ./dist && Aula56 && cd  ../
class Aula56
{
    public static void Main()
    {
        LinkedList<string> trasportes = new LinkedList<string>();

        trasportes.AddFirst("Avião");
        trasportes.AddFirst("Carro");
        trasportes.AddFirst("Moto");
        trasportes.AddFirst("Banana");

        foreach (string trasporte in trasportes)
        {
            Console.WriteLine(trasporte);
        }


        var noCarro = trasportes.Find("Carro");
        // LinkedListNode<string> noCarro = trasportes.FindLast("Carro");

        if(noCarro != null)
        {
            trasportes.AddAfter(noCarro, "Batata");
        }
 

        Console.WriteLine("\n\nApós inserção");
        foreach (string trasporte in trasportes)
        {
            Console.WriteLine(trasporte);
        }


        var depoisCarro = trasportes.Find("Carro").Next?.Value;

        Console.WriteLine($"Depois de carro vem: {depoisCarro}");
    }
}