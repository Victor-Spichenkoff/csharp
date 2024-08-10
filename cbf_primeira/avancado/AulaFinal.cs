//60 (58 == 59 parte 2)//Fila
using System;
using System.Collections.Generic;

class AulaFinal
{
    public static void Main(string[] args)
    {
        string[] vetor = new string[3]{"Carro", "Moto", "Ovo"};
        Queue<String> fila = new Queue<String>(vetor);

        fila.Enqueue("Fritada");
    }
}