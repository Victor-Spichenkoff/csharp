using System;

namespace avancado.aula47
{
    public class Calc
    {
        public int Soma(params int[] nums)
        {
            int final = 0;
            foreach (int num in nums)
            {
                final += num;
            }
            return final;df
        }

        public double Soma(params double[] nums)
        {
            double final = 0;
            foreach (double num in nums)
            {
                final += num;
            }
            return final;
        }


        public int Fatorial(int num)
        {
            int res = 1;
            if(num < 1) {
                res = 1;
            } else {
                res = num * Fatorial(num - 1);
            }

            return res;
        }
    }

    public class Aula4
    {
        public static void Main()
        {
            Calc c = new Calc();
            int resSoma = c.Soma(1, 2);
            var resSomaComTres = c.Soma(1.3, 2.2, 3.6);


            Console.WriteLine($"A soma é {resSoma}");
            Console.WriteLine($"A soma é {resSomaComTres}");


            int resFatorial = c.Fatorial(5);
            Console.WriteLine("O fatorial foi " + resFatorial);
        }
    }
}