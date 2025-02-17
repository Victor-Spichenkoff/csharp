using System;
using System.Collections.Generic;
using NSRandomNumber;
using NSJokenPo;
using Consoles;
using System.Diagnostics;
using toys;

class Program
{
    private static int totalGames = 3;

    private static void Help()
    {
        Console.Write(MyStrings.GetHelpTable());
        string? res = Console.ReadLine();
        int resNumber = 0;
        if(res != null) 
        {
            resNumber = int.Parse(res);
        }
        if(resNumber < 1 || resNumber > totalGames)
        {
            Console.Clear();
            Console.WriteLine("A ajuda que Vossa Anteza precisa é a escola!!!");
            Help();
        }

        if(resNumber == 1)
        {
            RandomNumber.Describe();
        }
    }

    private static void ChoseGame()
    {
        Console.Write(MyStrings.GetGamesTable());
        string? res = Console.ReadLine();
        if(res == "0") 
        {
            Console.Clear();
            Help();
        }

        if(res == "1")
            RandomNumber.Principal();

        if(res == "2")
            JokenPo.Principal();
        
        if(res == "3")
            Anagrams.Principal();
        
        if(res == "q")
        {
            Console.Clear();
            Console.WriteLine("Adeus");
            System.Environment.Exit(0);
            return;
        }


        ChoseGame();
    }
    public static void Main(string[] args)
    {
        Console.Clear();
        // Anagrams.Principal();
        ChoseGame();
        System.Environment.Exit(0);
    }
}