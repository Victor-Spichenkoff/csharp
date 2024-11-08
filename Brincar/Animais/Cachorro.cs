namespace Brincar.Animais;

public class Cachorro: Animal
{
    public Cachorro(int _id, string _name, int _idade)
    {
        id = _id;
        nome = _name;
        anos = _idade; 
    }
    public override void Falar()
    {
        Console.WriteLine($"\n\n{nome} diz: Au Au Au! \n");
    }

    public override void Anos()
    {
        Console.WriteLine($"\n\n{nome} tem: {anos} \n");
    }
}