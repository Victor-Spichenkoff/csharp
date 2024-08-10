using System;

namespace StructClass
{

    struct Carro
    {
        public string cor;
        public string marca;
        public string modelo;

        public Carro(string cor, string marca,string modelo)
        {
            this.cor = cor;
            this.marca = marca;
            this.modelo = modelo;
        }
    }
}

namespace StructClass{

    public class StructClass
    {
        public static void Main()
        {
            Carro c1; //= new Carro("Azul","VW", "Gol");
            c1.modelo = "Gol";

            Console.WriteLine("Modelo é " + c1.modelo);
        }
    }

}