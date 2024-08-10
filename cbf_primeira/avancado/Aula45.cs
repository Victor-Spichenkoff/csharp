using System;
//Array de strucs

namespace avancado.strucArray
{
    struct Carro
    {
        public string modelo;

        public readonly void Infos() 
        {
            Console.WriteLine("Modelo é " + this.modelo);
            Console.WriteLine("-----------------");
        }
    }


    public class Aula45
    {
        public static void Main() 
        {
            Carro[] carros = new Carro[2];
            
            carros[0].modelo = "Gol";
            carros[1].modelo = "Fusca";

        for(int c=0; c<carros.Length; c++) {
            carros[c].Infos();
        }

        }
    }
}