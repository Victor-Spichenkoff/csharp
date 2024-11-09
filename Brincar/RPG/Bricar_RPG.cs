using System.Threading;

namespace Brincar.RPG;

// flow
/*
 * Cria o personagem
 * cria o bot
 * fazem uma luta
 * alguém perdeu?
 *      FIM para o bot, reiniciar e dar vida ao player
 *          Mais vida ao player e novo bot
 *      Fim para o PLAYER, perguntar se quer mais
 * Sleep
 * Novo turno
 */

/*PROXIMOS
 * Não está morrendo
 * testar pelo fluxo
 * testar se consegue matar um bot e seguir
 * testar se consegue morrer
 * criar / interromper os ciclos
 */

public class Bricar_RPG
{
    public static void MakeOneBattle()
    {
        TurnManager.StopThisBattle = false;
        
        var player = new Player();
        player.Initialize();
        var bot = new Bot();
        bot.CreateNewBot();
        var turnManager = new TurnManager(player, bot);

        while (!player.CurrentPlayer.IsDead && !TurnManager.StopThisBattle)
        {
            turnManager.OneRound();
            Thread.Sleep(2000);
        }
    }
    
    
    public static void Rodar()
    {
        MakeOneBattle();


        // Console.WriteLine(p2.Vida);
    }
}