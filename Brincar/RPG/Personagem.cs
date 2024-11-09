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
            if (_vida - value < 0)
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
        var buff = random.Next(1, 21) / 10;
        inimigo.Defender(buff * Ataque);
        Logs.AtaqueInfos(Nome, inimigo.Nome, buff * Ataque);
    }
}