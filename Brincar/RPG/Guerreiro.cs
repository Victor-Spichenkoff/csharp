namespace Brincar.RPG;

public class Guerreiro : Personagem
{
    public Guerreiro(string nome) : base(100)
    {
        Nome = nome;
        Ataque = 25;
        Defesa = 0;
    }
}