namespace Brincar.Animais;

public abstract class Animal
{
    public static int lastId = 0;
    public string nome;
    public int anos = 0;
    public int id = 0;
    public bool isDog = true;


    public abstract void Falar();
    public abstract void Anos();
}