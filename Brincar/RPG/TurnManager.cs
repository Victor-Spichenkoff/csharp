namespace Brincar.RPG;

public class TurnManager(Player player, Bot bot)
{
    private int _wins = -1;
    private readonly Player _player = player;
    private Bot _bot = bot;
    public static bool StopThisBattle = false;
    
    
    

    public void OneRound()
    {
        if (_bot.CurrentBot != null) _player.MyTurn(_bot.CurrentBot);
        _bot.MyTurn(player.CurrentPlayer);
        
        if(_bot.CurrentBot.IsDead)
             BotLoseThis();
        if (_player.CurrentPlayer.IsDead)
            PLayerLose();
        
        Logs.LifeInfos(
            _player.CurrentPlayer.Nome, _player.CurrentPlayer.GetRemainingLifePercent(), 
            _bot.CurrentBot.Nome, _bot.CurrentBot.GetRemainingLifePercent()
        );
    }

    public void BotLoseThis()
    {
        Logs.YouWin(_bot.CurrentBot.Nome);
        var shouldCreateNewBattle = Input("Nova batalha[s/n]:").ToLower();
        if (shouldCreateNewBattle == "n")
        {
            TurnManager.StopThisBattle = true;
            return;
        }

        NewBattle();
    }

    private void PLayerLose()
    {
        Logs.YouLose(_bot.CurrentBot.Nome);
    }
    
    
    private int GiveLifeIncrease(int current, int maxLife)
    {
        var random = new Random();
        var increase = random.Next(maxLife - current);
        return current + increase > maxLife ? maxLife : increase;
    }

    public void NewBattle()
    {
        _bot = new Bot();
        _bot.CreateNewBot();
        _wins++;
        _player.CurrentPlayer.Vida +=
            GiveLifeIncrease((int)_player.CurrentPlayer.Vida, _player.CurrentPlayer.VidaInicial);
    }
}