namespace Brincar.RPG;

public class Bot
{
    public Personagem? CurrentBot = null;
    private static int currentBotNumber = 0;
    private readonly int _totalAvailablePersonagens = 4;

    public void CreateNewBot()
    {
        Bot.currentBotNumber++;
        // se primeira 99% que é goblin, o resto, reduz. 5 ou mais e é impossivel
        var easyPossiblillity = 0;
        if (currentBotNumber == 1)
            easyPossiblillity = 100;
        else if (7 - currentBotNumber >= _totalAvailablePersonagens)
            easyPossiblillity = 6 - currentBotNumber;
        else
            easyPossiblillity = _totalAvailablePersonagens;

        var random = new Random();
        var nextType = random.Next(0, easyPossiblillity);
        if (nextType == 0)
            CurrentBot = new Guerreiro($"Guerreiro_{currentBotNumber}");
        if (nextType == 1)
            CurrentBot = new Mago($"Mago_{currentBotNumber}");
        if (nextType == 2)
            CurrentBot = new Guerreiro($"Berserker_{currentBotNumber}");
        if (nextType >= _totalAvailablePersonagens - 1)
            CurrentBot = new Goblin($"Goblin_{currentBotNumber}");

        
    }


    public void MyTurn(Personagem player)
    {
        CurrentBot?.Atacar(player);
    }
}