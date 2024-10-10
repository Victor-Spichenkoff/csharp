global using static Brincar.Utils;
using System;


namespace Brincar;

internal class Logica_Madeiras
{
    static string woodType = "";
    static int qtd = 0;
    static double percent = 0;

    private static void GetWoodType()
    {
        while (true)
        {
            string res = Input(@"PIN - Pinehiro R$ 1000
MOG - Moglin R$ 2000
>>> ").ToUpper();

            string[] valids = ["PIN", "MOG"];

            if (valids.Contains(res))
            {
                woodType = res;
                break;
            }

            Console.WriteLine("Tipo inválido. Tente novamente");
        }
    }

    private static void GetQtd()
    {
        while (true)
        {
            try
            {
                int res = int.Parse(Input("Qual a quantidade (m³): "));

                if (res <= 2000 && res > 0)
                {
                    qtd = res;
                    break;
                }

                Console.WriteLine("Deve estar entre 1 e 2000");
            }
            catch
            {
                Console.WriteLine("Número, IDIOTA!");
            }
        }
    }


    private static double GetFinalPrice()
    {
        double original_price = 1;
        

        switch (woodType)
        {
            case "PIN":
                original_price = 210.10; break;
            case "MOG":
                original_price = 150.40; break;
            default:
                Console.WriteLine("MONDOLOIDE!"); break;
        }

        if (qtd > 100 && qtd < 500)
            percent = 0.04;
        else if (qtd < 1000)
            percent = 0.09;
        else if (qtd <= 2000)
            percent = 0.16;
        else
            percent = 1.7;


        Console.WriteLine($"qtd -> {qtd}\n Original:{original_price} \n percent {percent}");

        return (original_price * qtd) * (1 - percent) + 2500;
        //2500 == trasporte do exemplo
    }


    public static void Principal()
    {
        GetWoodType();

        GetQtd();

        double finalPrice = GetFinalPrice();

        Console.WriteLine($"O valor final para {qtd}m³ de {woodType} é: R$ {finalPrice}");
    }
}
