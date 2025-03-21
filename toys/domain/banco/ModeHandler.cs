﻿using System.ComponentModel.Design;
using Inputs;

namespace toys.banco;

public static class ModeHandler
{
    public static Modes SelectInitialType()
    {
        Console.WriteLine("\n[ 1 ] Login");
        Console.WriteLine("[ 2 ] Sign Up");
        Console.WriteLine("[ 3 ] Exit");
        Console.WriteLine("[ 4 ] Show all accounts");
        while (true)
        {
            var type = Input.String("What do you want to do? ");
            if (type == "1")
                return Modes.Login;
            else if (type == "2")
                return Modes.Register;
            else if (type == "3")
                return Modes.Exit;
            else if (type == "4")
                return Modes.ShowAccounts;

            Console.WriteLine("Wrong!");
        }
    }

    public static Modes SelectType()
    {
        Console.WriteLine("\n[ 1 ] Consult");
        Console.WriteLine("[ 2 ] Show Account Infos");
        Console.WriteLine("[ 3 ] Sake");
        Console.WriteLine("[ 4 ] Show Transfers");
        Console.WriteLine("[ 5 ] Deposit");
        Console.WriteLine("[ 6 ] Transfer");
        Console.WriteLine("[ 7 ] Undo Transfer");
        Console.WriteLine("[ 8 ] Change Information");
        Console.WriteLine("[ q ] Quit Action Mode");
        while (true)
        {
            var type = Input.String("What do you want to do? ");

            if (type == "1")
                return Modes.Consult;
            else if (type == "2")
                return Modes.ShowInformation;
            else if (type == "3")
                return Modes.Sake;
            else if (type == "4")
                return Modes.ShowTransfers;
            else if (type == "5")
                return Modes.Deposit;
            else if (type == "6")
                return Modes.Transfer;
            else if (type == "7")
                return Modes.UndoTransfer;
            else if (type == "8")
                return Modes.ChangeInformation;
            else if (type == "q")
                return Modes.SelectionInitial;

            Console.WriteLine("Wrong!");
        }
    }

    public static void LoggedModes()
    {
        var type = SelectType();
    }
}