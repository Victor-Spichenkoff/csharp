using System;

public class aula4 
{
    enum FinalSemana {Domingo, Sábado};
    static void Main() 
    {
        int indexDomingo = (int)FinalSemana.Domingo;
        Console.WriteLine(indexDomingo);

        double n1 = 12.5;
        int n2 = (int)n1;
        Console.WriteLine(n2);

        
        
        //Condicionais
        double nota = 9;
        string result = "Reprovado!";
        if(nota > 60) result = "Aprovado";
        else result = "10";
        Console.WriteLine(result);



        pergunta:
        //switch
        Console.Write("Qual o trasporte [a] [c] [n]: ");
        char escolha = (char)Console.ReadLine()[0];

        switch(escolha) 
        {
            case 'a':
                Console.WriteLine("Avião");
                break;
            case 'c':
                Console.WriteLine("Carro");
                break;
            case 'n':
                Console.WriteLine("Navio");
                break;
            default: 
                Console.Write("É burro? Ou Analfabeto?");
                break;
        }
        



        //go-to
        Console.Write\line("De novo [s][n]: ");
        string again = Console.ReadLine();

        Console.Clear();
        if(again == "s") goto pergunta;
        Console.Write("Fim");
    }
}