using toys.banco.types;
using toys.Data;

namespace toys.banco;

public class BankEntry(BankRepository br)
{
    private readonly BankRepository _br = br;
    private Modes _mode = Modes.SelectionInitial;
    private BaseAccount? _currentAccount = null;

    public void Run()
    {
        while (true)
        {
            if (_mode == Modes.SelectionInitial)
                _mode = ModeHandler.SelectInitialType();
            else if (_mode == Modes.Close)
                break;
            else if (_mode == Modes.SelectionLogged)
                _mode = ModeHandler.SelectType();
            else if (_mode == Modes.Login)
            {
                Console.WriteLine("Login");
                _mode = Modes.SelectionLogged;
            }
            // faltou register
            
            if(_mode == Modes.Consult)
                Console.WriteLine("Consut");
            else if(_mode == Modes.Sake)
                Console.WriteLine("Sakar");
            else if(_mode == Modes.Deposit)
                Console.WriteLine("Depositar");
            else if (_mode == Modes.Exit)
            {
                Console.WriteLine("Saindo");
                break;
            }
        }
    }
}

public enum Modes
{
    Login,
    Register,
    Sake,
    Consult,
    Deposit,
    SelectionInitial,
    SelectionLogged,
    Exit,
    Close
}