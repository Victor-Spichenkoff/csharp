namespace Brincar.RPG;

public class Bot
{
    public Personagem? CurrentBot = null;
    private int currentBotNumber = 1;
    
    public void CreateNewBot()
    {
        var random = new Random();
        var nextType = random.Next(1, 4);
        // if (nextType == 0)
            // currentBot = new Goblin($"Goblin - {currentBotNumber}");
        if (nextType == 1)
            CurrentBot = new Guerreiro($"Guerreiro - {currentBotNumber}");        
        if (nextType == 2)
            CurrentBot = new Mago($"Mago - {currentBotNumber}");        
        if (nextType == 3)
            CurrentBot = new Guerreiro($"Berserker - {currentBotNumber}");
    }


    public void MyTurn(Personagem player)
    {
        CurrentBot?.Atacar(player);
    }
}