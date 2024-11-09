namespace Brincar.RPG;

public class Player
{
    public Personagem CurrentPlayer = null;
    
    public void Initialize()
    {
        while ((true))
        {
            Console.WriteLine("1 - Guerreiro");
            Console.WriteLine("2 - Mago");
            Console.WriteLine("3 - Berserker");
            var type = Input("Qual o tipo> ");
            var name = Input("Digite o nome: ");

            if (type == "1")
                CurrentPlayer = new Guerreiro(name);
            if(type == "2")
                CurrentPlayer = new Mago(name);            
            if(type == "3")
                CurrentPlayer = new Berserker(name);
            
            if(type is "1" or "2" or "3")
                break;
        }
    }

    public void MyTurn(Personagem enemy)
    {
        CurrentPlayer?.Atacar(enemy);
    }
}