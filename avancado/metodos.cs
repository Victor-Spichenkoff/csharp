using System;

class Base {
    virtual public void infos() { Console.WriteLine("Base");  }
} 


class Filho: Base
{
    override public void infos() {
        Console.WriteLine("Classe Filho");
     }
}







abstract public class BaseAbstract 
{
    abstract public void consolarlogar(string txt);
}


public class FilhoAbstract: BaseAbstract 
{
    override public void consolarlogar(string txt) 
    {
        // Console.WriteLine("Implementei um metodo abstracct");
        Console.WriteLine(txt);
    }
}






//getters e setters
public class TesteGet 
{
    private int idade;

    public int idade
    {
        get {
            return idade;
        }
        set {
            //value == valor recebdo
            if(value < 123 && value > 0) idade = value;
        }
    }

    public TesteGet() 
    {
        idade = 0;
    }    

    //outra forma
    public void mudarIdade(int nova) 
    {
        if(nova < 123 || nova > 0) idade = nova;
    }
}




public class Metodos
{
    static void Main()
    {
        Base  Ref;
        Base b = new Base();
        Filho f1 = new Filho();


        //ref agora é do filho
        Ref = f1;
        Ref.infos();
        f1.infos();

        //agora ref é do pai(base)
        Ref = b;
        Ref.infos();



        //Abstract
        FilhoAbstract fa1 = new FilhoAbstract();
        fa1.consolarlogar("\n\n\nImplementei um metodo abstracct");

        //get set
        TesteGet t1 = new TesteGet();
        Console.WriteLine("\n\n\n{0}",t1.i);
        t1.i = 17;
        Console.WriteLine("\n{0}",t1.i);


    }
}