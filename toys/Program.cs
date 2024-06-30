using System;
using System.Collections.Generic;
using NSRandomNumber;
using Consoles;
using System.Diagnostics;

class Program
{
    private static int totalGames = 1;

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
        {
            RandomNumber.Principal();
        }
    }
    public static void Main(string[] args)
    {
        ChoseGame();
    }
}