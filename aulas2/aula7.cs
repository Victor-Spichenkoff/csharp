using System;

class Teste 
{
    public string nome;
    public Teste(string n) 
    {
        nome = n;
    }
    static int cont = 0;

    public void mais() 
    {
        cont++;
    }

    public int returnCont() { return cont; }
}



class Player 
{
    private int energia;// 0-100
    public string nome;
    public Player(string n)
    {
        nome = n;
    }

    public int getEnergia() 
    {
        return energia;
    }

    public void setEnergia(int novaEnergia) 
    {
        if(energia + novaEnergia < 0) energia = 0;
        else if(energia + novaEnergia > 100) energia = 100;
        else energia += novaEnergia;
        Console.WriteLine("Energia vale: "+energia);
    }
}  

class Aula7 
{
    static void Main()
    {
        Teste t1 = new Teste("Victor");
        Console.WriteLine(t1.nome);
        t1.mais();
        Console.WriteLine(t1.returnCont());

        //private
        Player p1 = new Player("Victor");
        Console.WriteLine(p1.nome);
        p1.setEnergia(-120);//-20//0
        p1.setEnergia(130);//110//100
        p1.setEnergia(-20);//90// 80

    }
}