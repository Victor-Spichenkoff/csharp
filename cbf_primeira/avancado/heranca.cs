// csc heranca.cs && heranca

using System;

class Carro
{
    public int id;
    public bool ligado;
    public string modelo;

    public Carro(int id, string m)
    {
        this.id = id;
        this.modelo = m;
        this.ligado = false;
    }

    public void ligar()
    {
        ligado = true;
    }

    public void desligar()
    {
        ligado = false;
    }

    public bool isLigado()
    {
        return ligado ? true : false;
    }

}


class Gol: Carro
{
    public Gol(int id):base(id, "Gol Special 2000")
    {
    }
}


class Special: Gol
{
    public int ano;
    public Special(int id, int a):base(id)
    {
        this.ano = a;
    }

}

public class heranca 
{
    static void Main()
    {
        Gol g1 = new Gol(17);
        Console.WriteLine(g1.ligado);
        g1.ligar();
        Console.WriteLine(g1.ligado);
        Console.WriteLine(g1.id);
        Console.WriteLine(g1.modelo);
        Console.WriteLine("Tá ligado: {0}", g1.isLigado());
    
        Console.WriteLine("\nSPECIAL:");
        Special s1 = new Special(17, 2000);
        Console.WriteLine("ID: {0}", s1.id);
        Console.WriteLine("Ano: {0}", s1.ano);
    }
}