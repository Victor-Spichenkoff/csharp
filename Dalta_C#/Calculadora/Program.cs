using System;
using Calculadora.Functions;
using Calculadora.Inputs;

public class Program
{
    static double currentN1;
    static double currentN2;
    static double result;
    static int option;
    static bool continueCalc = true;

    static void SwitchOpition()
    {
        switch (option)
        {
            case 1: result = Functions.Soma(currentN1, currentN2); break;
            case 2: result = Functions.Subtracao(currentN1, currentN2); break;
            case 3: result = Functions.Multiplicacao(currentN1, currentN2); break;
            case 4: result = Functions.Divisao(currentN1, currentN2); break;
            case 5:
                continueCalc = false;
                Console.WriteLine("Adeus!!@!@");
                System.Environment.Exit(0);
                break;
            default: break;
        }
    }

    public static void ShowResult()
    {
        Console.Clear();
        Console.WriteLine("-----------");
        Console.WriteLine($"O resultado foi {result}");
        Console.WriteLine("-----------");
    }


    public static void Main(string[] args)
    {
        Console.Clear();
        Inputs.MakeOneCicle(ref currentN1, ref currentN2, ref option);

        Console.WriteLine("A escolha foi " + option);
        SwitchOpition();
        ShowResult();

        while (continueCalc)
        {
            Inputs.MakeOneCicle(ref currentN1, ref currentN2, ref option);
            SwitchOpition();
            ShowResult();
        }
    }
}