using System;
using System.Text;

namespace Editor;

public static class Editor
{
    public static void Show()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        Console.WriteLine("Modo edição");
        Start();

    }

    public static void Start()
    {


        Console.WriteLine("-----------");
        var file = new StringBuilder();

        do
        {
            file.Append(Console.ReadLine());
            file.Append(Environment.NewLine);
        } while (Console.ReadKey().Key != ConsoleKey.Escape);



        Console.WriteLine("DDeseja salvar o arquivo [s, n]: ");
        var res = Console.ReadLine();
        if (res != "n")
        {
            var path = "C:\\Users\\Pichau\\CURSOS\\C#\\Dalta_C#\\EditorHTML\\html.html";

            using var fileWriter = new StreamWriter(path);
            fileWriter.Write(file);
            Viewer.Show(file.ToString());
        }
    }
}