namespace Brincar.RPG;

public class Logs
{
    public static void AtaqueInfos(string atacante, string defensor, int dano)
    {
        if (dano <= 0)
            Console.WriteLine($"{defensor} DEFENDEU o ataque de {atacante}");
        else
            Console.WriteLine($"{atacante} causou {dano} de dano em {defensor}");
    }

    public static void LifeInfos(string playerName, int vidaPlayerPercent, string botName, int botVidaPercent)
    {
        Console.WriteLine("===============================");
        Console.WriteLine($"{FormatarVida(playerName, vidaPlayerPercent)}");
        Console.WriteLine($"{FormatarVida(botName, botVidaPercent)}");
        Console.WriteLine("===============================");
    }

    public static void YouWin(string botName)
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine($"Parabéns, você venceu {botName}");
        Console.WriteLine("=================================");
    }

    public static void YouLose(string botName)
    {
        Console.Clear();
        Console.WriteLine("=================================");
        Console.WriteLine($"{botName} derrotou você");
        Console.WriteLine("=================================");
    }
        
    
    private static string FormatarVida(string nome, int percentVida)
    {
        var _percentVida = percentVida / 10;
        var lifePoints = "";
        for (var i = 1; i <= 10; i++)
        {
            lifePoints += i <= _percentVida ? "*" : "_";
        }
        return $"|{lifePoints}| -- {nome}";
    }
}