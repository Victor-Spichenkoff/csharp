using System;



delegate int Operacoes(int n1, int n2);



public class Mat
{ 
    public static int Soma(int n1, int n2)
    {

        return n1 + n2; 
    }    
    
    public static int Mult(int n1, int n2)
    {

        return n1 * n2;
    }
}


public class Aula50
{
    public static void Main()
    {
        int resSoma, resMult;
        Operacoes op1 = new Operacoes(Mat.Soma);


        resSoma = op1(10, 7);
        Console.WriteLine("Resposta da soma: ");
        Console.WriteLine(resSoma);

        //mudar de valor
        op1 = new Operacoes(Mat.Mult);

        resMult = op1(10, 7);


        Console.WriteLine("Resposta da multiplicação: ");
        Console.WriteLine(resMult);
    }
}
