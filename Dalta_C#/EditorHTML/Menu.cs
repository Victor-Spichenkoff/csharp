using System;
using System.Drawing;

namespace Editor;

static class Menu
{
    public static void Show()
    {
        Console.Clear();
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Black;
        DrawScreen();
        WriteOptions();

        var option = short.Parse(Console.ReadLine());
        HandleMenuOption(option);
    }

    public static void DrawScreen()
    {
        MakeHorizontalLine();

        for (var lines = 0; lines < 10; lines++)
        {
            Console.Write("|");
            for (var c = 0; c <= 30; c++)
                Console.Write(" ");

            Console.Write("|\n");
        }

        MakeHorizontalLine();
    }


    public static void WriteOptions()
    {
        Console.SetCursorPosition(3, 2);//left top
        Console.WriteLine("Editor HTML");

        Console.SetCursorPosition(3, 3);
        Console.WriteLine("============================");

        Console.SetCursorPosition(3, 4);
        Console.WriteLine("Selecione uma posição");
        
        Console.SetCursorPosition(3, 6);
        Console.WriteLine("1 - Novo Arquivo");
        Console.SetCursorPosition(3, 7);
        Console.WriteLine("2 - Abrir");
        Console.SetCursorPosition(3, 9);
        Console.WriteLine("0 - Sair");

        Console.Write("Opção: ");
        Console.SetCursorPosition(7, 10);
    }


    public static void HandleMenuOption(short option)
    {
        switch(option)
        {
            case 1: Editor.Show(); break;
            case 2: Viewer.Show(GetSavedHtml()); break;
            case 0: 
            {
                Console.Clear();
                Console.WriteLine("Saindo...");
                Environment.Exit(0);
                break;
            }
            default: Show(); break;

        }
    }


    public static string GetSavedHtml()
    {
        var path = "C:\\Users\\Pichau\\CURSOS\\C#\\Dalta_C#\\EditorHTML\\html.html";
        using var file = new StreamReader(path);

        return file.ReadToEnd();
    }


    // auxiliares sem bug
    public static void MakeHorizontalLine()
    {
        Console.Write("+");
        for (var c = 0; c <= 30; c++)
            Console.Write("-");

        Console.Write("+\n");
    }


}