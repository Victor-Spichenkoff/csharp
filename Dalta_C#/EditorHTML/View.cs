using System;
using System.Text.RegularExpressions;

namespace Editor;

class Viewer
{
    public static void Show(string text)
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("Modo VISUALIZAÇÂO");
        Console.WriteLine("-----------------");
        Replace(text);
        Console.WriteLine("-----------------");

        Console.ReadKey();
        Menu.Show();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
    }

    //proca as tags (<b>--> vira negrito)
    public static void Replace(string text)
    {
        var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
        
        var words = text.Split(' ');

        foreach (var word in words)
        {
            //ver se está entr o <strong>
            if(strong.IsMatch(word))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(word.Substring(
                    word.IndexOf('>') + 1,
                    (
                        (word.LastIndexOf('<') - 1) - word.IndexOf('>')
                    )
                ));

                Console.Write(" ");
            } else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(word);
                Console.Write(" ");
            }
        }
    }
}