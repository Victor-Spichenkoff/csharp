using System.ComponentModel.Design;
using Inputs;

namespace toys.banco;

public static class ModeHandler
{
    public static Modes SelectInitialType()
    {
        
        Console.WriteLine("[ 1 ] Login");
        Console.WriteLine("[ 2 ] Sign Up");
        Console.WriteLine("[ 3 ] Exit");
        while (true)
        {
            var type = Input.String("What do you want to do? ");
            if(type == "1")
                return Modes.Login;
            else if (type == "2")
                return Modes.Register;
            else if (type == "3")
                return Modes.Close;
            
            Console.WriteLine("Wrong!");
        }
    }
    
    public static Modes SelectType()
    {
        Console.WriteLine("[ 1 ] Consult");
        Console.WriteLine("[ 2 ] Sake");
        Console.WriteLine("[ 3 ] Deposit");
        Console.WriteLine("[ q ] Quit Action Mode");
        while (true)
        {
        var type = Input.String("What do you want to do?");
        
        if(type == "1")
            return Modes.Consult;
        else if (type == "2")
            return Modes.Sake;
        else if (type == "3")
            return Modes.Deposit;        
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