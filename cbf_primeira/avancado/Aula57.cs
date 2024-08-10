using System;
using System.Collections.Generic;


class Aula57
{
    public static void Main()
    {
        LinkedList<string> transp = new LinkedList<string>();

        transp.AddLast("Carro");
        transp.AddLast("Avião");
        transp.AddLast("Batata");
        transp.AddLast("Bicicleta");
        transp.AddLast("Roda");
        transp.AddLast("Horse");

        foreach (string trasporte in transp)
        {
            Console.WriteLine(trasporte);
        }

        LinkedListNode<string>? noRoda = transp.Find("Roda");

        if (noRoda != null)
        {
            transp.AddAfter(noRoda, "Após a roda");
        }

        // LISTA
        foreach (string trasporte in transp)
        {
            Console.WriteLine(trasporte);
        }

    }
}