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
    public static void InitializeBattle()
    {
        TurnManager.StopAllBattles = false;

        var player = new Player();
        player.Initialize();
        var bot = new Bot();
        bot.CreateNewBot();
        var turnManager = new TurnManager(player, bot);

        while (!player.CurrentPlayer.IsDead && !TurnManager.StopAllBattles)
        {
            turnManager.OneRound();

            if (player.CurrentPlayer.IsDead)
                return;
            
            var res = Input("Continuar? [s/n]: ");
            Console.WriteLine("\n");
            if (res == "n")
                return;
        }
    }

    public static void MakeOneBattle()
    {
        while (!TurnManager.StopAllBattles)
        {
            InitializeBattle();
        }
    }


    public static void Rodar()
    {
        MakeOneBattle();

        Console.Clear();

        Console.WriteLine("Adeus 👍");
    }
}