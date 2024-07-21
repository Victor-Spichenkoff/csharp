using System;
using System.IO;

class Program
{
    static readonly string aplicationPath = "C:\\Users\\Pichau\\CURSOS\\C#\\Dalta_C#\\Text_Editor\\Texto.txt";
    static void Menu()
    {
        Console.Clear();
        Console.WriteLine("O que vai fazer?");
        Console.WriteLine("1 - Abrir Aqruivo");
        Console.WriteLine("2 - Criar Arquivo");
        Console.WriteLine("0 - Sair");
        Console.Write("O que vai ser? ");
        short option = 0;
        var res = Console.ReadLine();
        if (res != null)
            option = short.Parse(res);

        switch (option)
        {
            case 0: Console.Write("ADEUS!"); System.Environment.Exit(0); break;
            case 1: Abrir(); break;
            case 2: Editar(); break;
            default: Menu(); break;
        }
    }


    static void Abrir()
    {
        Console.Clear();
        Console.WriteLine("TEXTO: ");
        Console.WriteLine("------------------");

        using (var file = new StreamReader(aplicationPath))
        {
            Console.WriteLine(file.ReadToEnd());
        }

        Console.WriteLine("");
        Console.ReadLine();
        Menu();
    }

    static void Editar()
    {
        string fullText = "";
        Console.Clear();
        Console.WriteLine("Digite seu texto [nova linha+esc = sair]: ");
        Console.WriteLine("----------");

        do
        {
            fullText += Console.ReadLine();
            fullText += Environment.NewLine;//não e colocado automaticamnte
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);

        Salvar(fullText);
    }

    static void Salvar(string text)
    {
        Console.WriteLine("Caminho: [C:\\Users\\Pichau\\CURSOS\\C#\\Dalta_C#\\Text_Editor\\]: ");
        // var path = "C:\\Users\\Pichau\\CURSOS\\C#\\Dalta_C#\\Text_Editor\\Texto.txt"; //Console.ReadLine();
                                                                             // var path = Console.ReadLine();
        using (var file = new StreamWriter(aplicationPath))
        {
            file.Write(text);
        }

        Console.WriteLine($"Arquivo salvo com sucesso: [ {aplicationPath} ]");
        // Console.ReadLine();
        Menu();

    }


    static void Main(string[] args)
    {
        Menu();
    }
}