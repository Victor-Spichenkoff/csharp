namespace Brincar.RPG;

public class Goblin : Personagem
{
    public Goblin(string nome) : base(40)
    {
        Nome = nome;
        Ataque = 15;
        Defesa = 0;
    }
}