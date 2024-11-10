namespace Brincar.RPG;

public class Berserker: Personagem
{
    public Berserker(string nome) : base(200)
    {
        Nome = nome;
        Ataque = 15;
        Defesa = 40;
    }
}