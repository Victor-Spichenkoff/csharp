namespace Brincar.RPG;

public class TurnManager(Player player, Bot bot)
{
    private int _wins = -1;
    private readonly Player _player = player;
    private Bot _bot = bot;
    
    public static bool StopAllBattles = false;
    public static int BattlesCount = 0;
    

    public void OneRound()
    {
        // cada um executa um ataque + verificações
        if (_bot.CurrentBot != null) _player.MyTurn(_bot.CurrentBot);

        Thread.Sleep(2000);
        
        
        // ver se já morreu (não jogar)
        if(!_bot.CurrentBot.IsDead) 
            _bot.MyTurn(player.CurrentPlayer);
        else
            Console.WriteLine($"{_bot.CurrentBot.Nome} foi DERROTADO");


        
        Logs.LifeInfos(
            _player.CurrentPlayer.Nome, _player.CurrentPlayer.GetRemainingLifePercent(), 
            _bot.CurrentBot.Nome, _bot.CurrentBot.GetRemainingLifePercent()
        );
        
        // mostrar só no final se ganhou
        if (_player.CurrentPlayer.IsDead)
            PLayerLose();
        
        if(_bot.CurrentBot.IsDead)
            BotLoseThis();
    }

    public void BotLoseThis()
    {
        Logs.YouWin(_bot.CurrentBot.Nome);
        var shouldCreateNewBattle = Input("Nova batalha[s/n]:").ToLower();
        if (shouldCreateNewBattle == "n")
        {
            TurnManager.StopAllBattles = true;
            return;
        }

        NewBattle();
    }

    private void PLayerLose()
    {
        Logs.YouLose(_bot.CurrentBot.Nome);
        
        
        var shouldCreateNewBattle = Input("Nova batalha[s/n]:").ToLower();
        if (shouldCreateNewBattle == "n")
        {
            TurnManager.StopAllBattles = true;
            return;
        }
    }
    
    
    private int GiveLifeIncrease(int current, int maxLife)
    {
        var random = new Random();
        var increase = random.Next(maxLife - current);
        return current + increase > maxLife ? maxLife : increase;
    }

    public void NewBattle()
    {
        TurnManager.StopAllBattles = false;
        _bot = new Bot();
        _bot.CreateNewBot();
        _wins++;
        var increaseLife = GiveLifeIncrease((int)_player.CurrentPlayer.Vida, _player.CurrentPlayer.VidaInicial);
        _player.CurrentPlayer.Vida += increaseLife;
        Console.WriteLine($"Sua vida foi recuperada em {increaseLife} -> {_player.CurrentPlayer.Vida}");
    }
}