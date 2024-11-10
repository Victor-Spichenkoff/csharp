namespace Brincar.RPG;

public class Personagem
{
    public int VidaInicial;
    private int _vida;
    public string Nome = "Desconhecido";
    public bool IsDead = false;

    protected Personagem(int vidaInicial)
    {
        VidaInicial = vidaInicial;
        _vida = VidaInicial;
    }


    public double Vida
    {
        get => _vida;
        set
        {
            if (value <= 0)
            {
                _vida = 0;
                Morrer();
            }
            else
                _vida = (int)value;
        }
    }

    public int GetRemainingLifePercent() => (int)((double)_vida / VidaInicial * 100);
    
    protected int Ataque { get; set; }
    protected int Defesa { get; set; }

    private void Morrer() => IsDead = true;

    public void Defender(int ataqueInimigo)
    {
        if (ataqueInimigo > Defesa)
            Vida -= ataqueInimigo;
    }

    public void Atacar(Personagem inimigo)
    {
        var random = new Random();
        double buff = random.Next(1, 21);
        // inimigo.Defender(buff * Ataque);
        var finalDamage = (int)Math.Ceiling(buff / 10 * Ataque);
        inimigo.Defender(finalDamage);
        Logs.AtaqueInfos(Nome, inimigo.Nome, finalDamage);
        // Logs.AtaqueInfos(Nome, inimigo.Nome, buff * Ataque);
    }
}