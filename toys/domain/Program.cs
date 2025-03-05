using NSRandomNumber;
using NSJokenPo;
using Consoles;
using Microsoft.Extensions.DependencyInjection;
using toys;
using toys.banco;
using toys.Data;
using toys.password;

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
        
        if(res == "4")
            Password.Principal();
        
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
        var scope = ContextUtils.ConfigureDI();
        var br = scope.ServiceProvider.GetRequiredService<BankRepository>();
        var Bank = new BankEntry(br);
;        Bank.Run();
        // Console.Clear();
        // Password.Principal();
        // ChoseGame();
        System.Environment.Exit(0);
    }
}