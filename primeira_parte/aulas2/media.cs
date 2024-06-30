using System;

public class aula5 {
    static void Main()
    {
        Console.Write("Quantas Notas: ");
        int notas = int.Parse(Console.ReadLine());
        Console.Write("Tem pesos distintos [s], [n]: ");
        char temPesos = (char)Console.ReadLine()[0];

        int finalSoma = 0;
        int finalBaixo = notas;
        for(int i=0; i < notas; i++)
        {
            Console.Write("Nota atual: ");
            int notaAtual = int.Parse(Console.ReadLine());

            if(temPesos == 's') 
            {
                Console.Write("Peso dessa nota: ");
                int pesoAtual = int.Parse(Console.ReadLine());
                finalBaixo += (pesoAtual - 1);

                notaAtual *= pesoAtual;
            }

            finalSoma += notaAtual;

            Console.Clear();
        }

        float final = finalSoma/finalBaixo;
        Console.WriteLine("Nota final: {0:f}", final);
    }
}