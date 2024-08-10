using System;
using System.Globalization;



namespace aulas2
{
    class Program
    {
        static void Main(String[] args) 
        {
            CultureInfo culture = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Console.WriteLine("Olá, Mundo (parte 2)!");
            
            for(int count = 0; count < 10; count += 1) {
                Console.WriteLine(count);
            }


            
            bool exits = sair();
            if(exits == true) return;

            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            // nome = FormatName(nome);
            Console.Write("nota 1: ");
            double n1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("nota 2: ");
            double n2 = Convert.ToDouble(Console.ReadLine());
            
            double media = (n1 + n2) / 2;
            Console.WriteLine(n1 + n2);
            Console.WriteLine((n1 + n2)/2);
            Console.WriteLine("Aluno: " + nome);
            Console.WriteLine("Media final: " + media);


            Console.WriteLine("FIM!");
            
            // if(args.GetLength(0) > 0)
            // {
            //     Console.WriteLine(args.GetValue(0));
            // }
        }

        // static private String FormatName(String nome) 
        // {
        //     return nome[0].ToUpperCase() + nome.SubString(1);
        // }


        static bool sair() 
        {
            Console.Write("Quer sair(s, n)");
            string res = Console.ReadLine();
            if(res == "s" || res=="S") return true;
            return false;
        }
    }
};