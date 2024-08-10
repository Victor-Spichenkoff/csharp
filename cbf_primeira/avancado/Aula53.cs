using System;

//excessão == derivado da classe Exception

public class Aula50
{
    public static void Main()
    {
        int n1, n2, res;
        n1 = n2 = res = 0;

        n1 = 170;
        n2 = 10;

        try
        {
            res = n1 / n2;
            Console.WriteLine($"{n1} / {n2} = {res}");
            Console.WriteLine("Vou forçar erro!");

            throw new Exception("ERRO MEU<>");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro! {e.Message}");
            Console.WriteLine($"Erro PURO! {e}");
        }
        finally
        {
            Console.WriteLine("FIM");
        }
    }
}
