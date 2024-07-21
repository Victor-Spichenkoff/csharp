using System;
using Inputs;
using Consoles;

namespace NSJokenPo;

enum EOptions
{
    Nenhum = 0,
    Pedra = 1,
    Papel = 2,
    Tesoura = 3,
}


public class JokenPo
{
    private static int Rounds;
    private static int PLayerWins;
    private static EOptions PlayerOption;
    private static EOptions BotOption;

    private static bool venceu = false;
    private static bool perdeu = false;


    public static void Idiota()
    {
        Console.Clear();
        Console.WriteLine("Escreve direito, IDIOTA!");
    }

    public static void Reset()
    {
        Console.Clear();
        PlayerOption = EOptions.Nenhum;
        BotOption = EOptions.Nenhum;
        venceu = false;
        perdeu = false;
    }


    private static bool checkWin()
    {
        if (PlayerOption == EOptions.Papel && BotOption == EOptions.Pedra)
            return true;

        if (PlayerOption == EOptions.Tesoura && BotOption == EOptions.Papel)
            return true;

        if (PlayerOption == EOptions.Pedra && BotOption == EOptions.Tesoura)
            return true;

        return false;
    }

    private static bool checkLose()
    {
        if (PlayerOption == EOptions.Pedra && BotOption == EOptions.Papel)
            return true;

        if (PlayerOption == EOptions.Papel && BotOption == EOptions.Tesoura)
            return true;

        if (PlayerOption == EOptions.Tesoura && BotOption == EOptions.Pedra)
            return true;

        return false;
    }

    private static void GetPlayerOption()
    {
        int choose = Input.Int(MyStrings.GetjokenPoTableOptions);
        if (choose < 1 || choose > 3)
        {
            Idiota();
            GetPlayerOption();
            return;
        }

        PlayerOption = (EOptions)choose;
        Random random = new();
        BotOption = (EOptions)random.Next(1, 4);
    }

    private static void AnotherCicle()
    {
        // Console.WriteLine($"\nVocê jogou    {PlayerOption.ToString().ToUpper()} \nEu joguei     {BotOption.ToString().ToUpper()}");
        Console.WriteLine("----------");
        Console.WriteLine("EMPATE, tente outra vez");
        Console.WriteLine("----------");
        Start(true);
    }
    public static void Start(bool notClear = false)
    {
        if (!notClear)
            Reset();

        GetPlayerOption();

        venceu = checkWin();
        perdeu = checkLose();

        Console.Clear();
        Console.WriteLine($"\nVocê jogou    {PlayerOption.ToString().ToUpper()} \nEu joguei     {BotOption.ToString().ToUpper()}");
        if (!venceu && !perdeu)
        {
            AnotherCicle();
            return;
        }

        if (perdeu)
            FinalScreen(false);

        if (venceu)
            FinalScreen(true);
    }

    public static void FinalScreen(bool venceu)
    {
        Console.WriteLine(venceu ? "Você VENCEU!!!" : "Você Perdeu!");
        Rounds++;
        if (venceu)
            PLayerWins++;

        Console.WriteLine($"Rodas:     {Rounds}\nVitórias:  {PLayerWins}");
        char res = Input.String("Mais uma? [s, n]: ")[0];
        if (res == 's')
        {
            Start();
        }
    }
    public static void Principal()
    {
        Start();
    }
}