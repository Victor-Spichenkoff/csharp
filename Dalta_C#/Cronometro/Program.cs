using System;
class Program
{
    private static double countDecimos = 0;

    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("s - Contagem em SEGUNDOS (10s)");
        Console.WriteLine("m - Contagem em MINUTO (10m)");
        Console.WriteLine("0 - SAIR");
        Console.Write("Contar por quanto tempo: ");

        string? data = Console.ReadLine()?.ToLower();
        // data[data.Length - 1]
        if(data == null)
        {
         Menu(); 
         return ;
        }    
        char type = data[^1];
        int time = int.Parse(data.Substring(0, data.Length-1));
        //Professor:
        // char type = data.Substring(data.Length-1, 1);
        if(time == 0)
            System.Environment.Exit(0);
        
        int convertedTime = time * (type == 'm' ? 60 : 1);
        Start(convertedTime);
        Console.Clear();    
        Console.WriteLine($"Cronômetro finalizado: {time}{type}");
        Thread.Sleep(2000);
    }


    static void Start(int time)
    {
        int currentTime = 0;

        while (currentTime != time)
        {
            Console.Clear();    
            currentTime++;
            Console.WriteLine($"ATUAL: {currentTime}");
            Thread.Sleep(1000);
        }
    }


    public static void Main()
    {
        Menu();

    }


}