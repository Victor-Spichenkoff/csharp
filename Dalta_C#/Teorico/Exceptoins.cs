using System;

namespace Teorico;

public class MinhaEx : Exception
{
    public string MinhaMenssagem = "Esse é meu erro";

    public MinhaEx(string msg)
    {
        MinhaMenssagem = msg;
    }
    public MinhaEx(){}

    //não pode ser estatioco 


    public DateTime QuandoDeuErro()
    {
        return DateTime.Now;
    }
}


class ExceptionClass
{
    public static void Rodar()
    {
        Console.WriteLine("MINHA EXCEPTION");
        try
        {
            TestarMinhaException();
        }
        catch (MinhaEx meu)
        {
            Console.WriteLine(meu.MinhaMenssagem);
            Console.WriteLine("Menssagem do exception" + meu.Message);
            Console.WriteLine("Inner> " + meu.InnerException);
            Console.WriteLine("ERRO ÀS: " + meu.QuandoDeuErro());
        }


        Console.WriteLine("\n\n-----------------\n");
        try
        {
            Salvar("");
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine("\n\n-----------------\n");
        ArrayOutOfIndex();
    }





    static void TestarMinhaException()
    {
        throw new MinhaEx();
        // throw new MinhaEx("Mensagem passada para o contrutor");
    }


    static void Salvar(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            throw new ArgumentNullException("Escreva algo");
        }

        Console.WriteLine("salvo: " + text);
    }


    static void ArrayOutOfIndex()
    {
        var array = new int[3];

        try
        {
            for (var i = 0; i < 10; i++)
            {
                //System.IndexOutOfRangeException
                var res = 1 / array[i];
                Console.WriteLine(array[i]);
            }
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Divisão por zero");
        }


        catch (Exception e)
        {
            Console.WriteLine($"Algo deu errado!");
            Console.WriteLine("Inner Expection " + e.InnerException);
            Console.WriteLine("Message " + e.Message);

        }
    }
}