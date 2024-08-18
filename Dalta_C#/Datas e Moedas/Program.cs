using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        if(!args.Contains("--no-date"))
            Datas();
        
        
        if(!args.Contains("--no-money"))
            Money();        
    }

    public static void Datas()
    {
        var dataAtual = DateTime.Now;
        Console.WriteLine("Atual: " + dataAtual);

        //Criar a data:
        var nascimento = new DateTime(2006, 1, 20, 2, 40, 2);
        Console.WriteLine("Nascimento: " + nascimento);
        Console.WriteLine("Dia da semana: " + nascimento.DayOfWeek);

        //Formatando
        // var dataFormatavel = new DateTime(2024, 8, 17, 23, 12, 17);
        var dataFormatavel = DateTime.Now;
        //y, M==Mes, d, m==minuto, s 
        // var formatada = String.Format("{0}:", dataFormatavel);
        var formatada = String.Format($"{dataFormatavel:dd/MM/yyy fff z}");
        Console.WriteLine("Data formatada: " + formatada);

        var formatadaPredefinidos = String.Format($"{dataFormatavel:g}");
        Console.WriteLine("Predefinidos: " + formatadaPredefinidos);


        //Culture info
        var br = new CultureInfo("pt-br");
        var us = new CultureInfo("en-US");
        var denmark = new CultureInfo("de-DE");

        var horaBrasil = DateTime.Now.ToString("g", br);
        var horaUS = DateTime.Now.ToString("g", us);
        var horaDemark = DateTime.Now.ToString("g", denmark);

        Console.WriteLine("Hora no Brasil: " + horaBrasil);
        Console.WriteLine("Hora no US: " + horaUS);
        Console.WriteLine("Hora no Dinamarca: " + horaDemark);
    }



    public static void Money()
    {
        decimal dinheiros = 17.12m;
        var br = new CultureInfo("pt-BR");
        var us = new CultureInfo("en-US");
        var de = CultureInfo.CreateSpecificCulture("de-DE");


        Console.WriteLine("Dinheiros: " + dinheiros.ToString(us));
        Console.WriteLine("Dinheiros Dinamarca: " + dinheiros.ToString(de));
        Console.WriteLine("Formação predefinidada: " +
            dinheiros.ToString("E04", br)
            );
        
            
        Console.WriteLine("Arrendondar: "+ Math.Round(dinheiros));
        Console.WriteLine("Arrendondar Baixo: " + Math.Floor(dinheiros));
        Console.WriteLine("Arrendondar Cima: " + Math.Ceiling(dinheiros));
    }
}