using System;

namespace avancado.aula49
{
    public class Mat
    {
        public double pi = 3;

        public double area(double raio)
        {
            return raio*raio * pi;
        }

        static int Somar (int n1, int n2)
        {
            return n1 + n2;
        }
    }

    public class Aula49
    {

        public static void Main()
        {
            var area = Mat.area(2);
            Console.WriteLine(area);
        }
    }
}