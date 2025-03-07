using toys.banco.Actions.Create;
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
            
            if (_mode == Modes.Login)
            {
                var auth = new Auth(_br);
                var accountInfo = auth.Login();
                _currentAccount = CreateCorrectClass.GiveAccount(accountInfo);
                _mode = Modes.SelectionLogged;
            }
            else if (_mode == Modes.Register)
            {
                var auth = new Auth(_br);
                var accountInfo = auth.CreateAccount();
                _currentAccount = CreateCorrectClass.GiveAccount(accountInfo);
                _mode = Modes.SelectionLogged;
            }
            
            if(_mode == Modes.Consult)
                Console.WriteLine("Consut");
            else if(_mode == Modes.Sake)
                Console.WriteLine("Sake");
            else if(_mode == Modes.Deposit)
                Console.WriteLine("Depositar");
            else if (_mode == Modes.Close)
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