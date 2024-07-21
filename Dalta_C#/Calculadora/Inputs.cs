using System;

namespace Calculadora.Inputs;

public class Inputs
{
    public static string Input(string label)
    {
        Console.Write(label);
        var res = Console.ReadLine();

        if(res != null)
            return res;

        return Input(label);
    }


    public static double GetNumber(string label)
    {
        double num = 0;
        try
        {
            string res = Input(label);
            num = double.Parse(res);
        } catch 
        {
            Console.WriteLine("IDIOTA!");
            GetNumber(label);
        }

        return num;
    }


    private static string CurrentOperationLabel =@"Qual Operação:
1 - Soma
2 - Subtração
3 - Multiplicação
4 - Divisão
5 - Sair

Escolha: ";


    public static short GetCurrentOperation()
    {   
        short[] valids = [1, 2, 3, 4 , 5];

        string res = Input(CurrentOperationLabel);
        short finalResponse = short.Parse(res);
        if(valids.Contains(finalResponse))
        {
            return finalResponse;
        }

        Console.WriteLine("BURRO!");
        return GetCurrentOperation();
    }


    public static void MakeOneCicle(ref double n1, ref double n2, ref int option)
    {
        option = GetCurrentOperation();
        if(option == 5)
            return;
        n1 = GetNumber("Qual o primeiro número: ");
        n2 = GetNumber("Qual o segundo número: ");
    }
}