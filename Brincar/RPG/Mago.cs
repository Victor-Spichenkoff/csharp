namespace Brincar.RPG;

public class Mago : Personagem
{
    public Mago(string nome) : base(50)
    {
        Nome = nome;
        Ataque = 50;
        Defesa = 10;
    }
}