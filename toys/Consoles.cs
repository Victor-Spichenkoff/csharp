namespace Consoles;

class MyStrings {
    public static string GetGamesTable()
    {
        return @"Qual Jogo: 
    [0] - Ajuda
    [1] - Adivinhe o número 
    [2] - Jokenpô
    [q] - Sair
Escolha: ";
    }

    public static string GetHelpTable() 
    {
        return @"Saber mais sobre qual:" + GetOnlyGames();
    }

    public static string GetOnlyGames()
    {
        return @"
    [1] - Adivinhe o número
Escolha: ";
    }


    public static string GetjokenPoTableOptions = 
@"[1] - Pedra
[2] - Papel
[3] - Tesoura
Sua jogada: ";

}