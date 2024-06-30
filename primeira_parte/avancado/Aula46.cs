//METODOS QUE IMPLEMENTAM OUTROS METODOS
using System;
namespace avancado.aula46
{
    public class Galinha 
    {
        private string nomeGalinha;
        private int numOvo;
        public Galinha(string nomeGalinha)
        {
            this.nomeGalinha = nomeGalinha;
            numOvo = 0;
        }

        public Ovo BotarOvo()//ovo==retorno
        {
            numOvo ++;
            return new Ovo(numOvo, nomeGalinha);
        }
    }

    public class Ovo
    {
        private int numOvo;
        private string nomeGalinhaOrigem;
        public Ovo(int numOvo, string nomeGalinhaOrigem) 
        {
            this.nomeGalinhaOrigem = nomeGalinhaOrigem;
            this.numOvo = numOvo;
            Console.WriteLine("Ovo Criado, número: " + this.numOvo + " da galinha " + this.nomeGalinhaOrigem);
            Console.WriteLine("-------------");
        }
    }

    public class Aula46
    {
        public static void Main() 
        {
            Galinha g1 = new Galinha("Cocorico");
            Galinha g2 = new Galinha("F");
            Galinha g3 = new Galinha("Galinha III");

            g1.BotarOvo();
            g1.BotarOvo();
        }
    }
}