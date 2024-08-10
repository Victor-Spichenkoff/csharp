using System;

namespace coisasRandom
{
    public class Formas
    {
        private string repeat(char character, int times)
        {
            string final = "";

            for (int i = 0; i < times; i++)
            {
                final += character;
            }
            return final;
        }

        static char icon = '*';

        public string MakePiramid(int levels)
        {
            string final = "";
            for (int line = 0; line < levels; line++)
            {
                final += repeat(icon, line + 1) + "\n"; // Chamando o método repeat corretamente
            }

            return final;
        }
    }

    public class Triangulo
    {
        public static void Main()
        {
            Formas formas = new Formas();
            string result = formas.MakePiramid(5);

            Console.WriteLine("Resultado:");
            Console.WriteLine(result);
            Console.WriteLine("=--------------=");

            string result2 = formas.MakePiramid(40);
            Console.WriteLine("Resultado 2:");
            Console.WriteLine(result2);
        }
    }
}
