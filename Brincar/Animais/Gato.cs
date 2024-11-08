namespace Brincar.Animais;

public class Gato: Animal
{
    public Gato(int _id, string _name, int _idade)
    {
        id = _id;
        nome = _name;
        anos = _idade; 
        isDog = false;
    }
    
    
    public override void Falar()
    {
        Console.WriteLine($"\n\n{nome} diz: Miau Miau \n");
    }

    public override void Anos()
    {
        Console.WriteLine($"\n\n{nome} tem: {anos} \n");
    }
}