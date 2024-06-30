using System;

public class Aula6
{
    static void Main()
    {

        teste();
        Console.WriteLine(soma(2, 4));
        int varMudavel = -1;
        mudar(ref varMudavel);
        Console.WriteLine("Variavel nova {0}", varMudavel);

        // teste do OUT
        int n1 = 10;
        int n2 = 3;
        int meuResto;

        int resultado = dividirEResto(n1, n2, out meuResto);
        Console.WriteLine("Resultado = {0}; Resto = {1}", resultado, meuResto);


        //PARAMS
        Console.WriteLine(somarInfinitos(10, 7));
    }

    static int somarInfinitos(int n1, int n2, params int[] extraNums) 
    {
        int res = n1 + n2;
        if(extraNums.Length > 0);
        {
            foreach (var num in extraNums)
            {
                res += num;
            }
        }

        return res;
    }


    static int dividirEResto(int n1, int n2, out int res)
    {
        res = n1%n2;
        return n1/n2;
    }


    static void formatacaoBonita(/*string text*/) 
    {
        // Console.WriteLine($"Hello, {name}! Today is , it's now.");
    }

    static void teste() 
    {
        Console.WriteLine("Detro do metodo");
    }

    static int soma(int n1, int n2) 
    {
        return n1 + n2;
    }     

    static int menos(int n1, int n2)
    {
        return n1 - n2;
    }                 



    static void mudar(ref int variavel) 
    {
        Random r = new Random();
        variavel = r.Next(1, 100);
    }                            

    static void testarrandom()
    {
        for(int c=0; c < 1000; c++)
        {
            int n;
            Random r = new Random();
            n = r.Next(1, 100);
            if(n == 100)
            {
                Console.WriteLine("Deu 100");
                break;
            }
            Console.WriteLine("Mais um "+c);
        }
    }                                                                                                                                                                                                                                          
}

