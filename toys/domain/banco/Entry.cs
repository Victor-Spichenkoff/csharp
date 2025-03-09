using Microsoft.Extensions.DependencyInjection;
using toys.banco.Actions.Create;
using toys.banco.types;
using toys.Data;

namespace toys.banco;

public class BankEntry
{
    private readonly BankRepository _br;
    private Modes _mode = Modes.SelectionInitial;
    private BaseAccount? _currentAccount = null;

    public BankEntry()
    {
        var serviceProvider = ContextUtils.ConfigureDI();

        var scope = serviceProvider.CreateScope();
        _br = scope.ServiceProvider.GetRequiredService<BankRepository>();
        //TODO:> pediu para ser assim
        // using (var scope = serviceProvider.CreateScope())
        // {
        //     _br = scope.ServiceProvider.GetRequiredService<BankRepository>();
        // }
    }

    public void RunningMode()
    {
        while (true)
        {
            if (_mode == Modes.SelectionInitial)
            {
                _mode = ModeHandler.SelectInitialType();
                continue; // para não usar o Sleep
            }
            else if (_mode == Modes.Close)
                break;
            else if (_mode == Modes.SelectionLogged) // já logado, o que fazer?
            {
                _mode = ModeHandler.SelectType();
                continue; // para não passar pelo Sleep
            }

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


            // controlar as açoes pós login
            switch (_mode)
            {
                case Modes.Consult:
                    _mode = Modes.SelectionLogged;
                    _currentAccount?.GetBalance();
                    break;
                case Modes.Sake:
                    _currentAccount?.Sake();
                    _mode = Modes.SelectionLogged;
                    break;
                case Modes.ShowTransfers:
                    _currentAccount?.ShowTransfers();
                    _mode = Modes.ShowTransfers;
                    break;
                case Modes.Close:
                    Console.WriteLine("Closing Bank");
                    break;
                    break;
                default: break;
            }

            // Deixar melhor de ler
            // if (_mode == Modes.SelectionLogged)
            //     Thread.Sleep(2000);
        }
    }


    public void Run()
    {
        RunningMode();
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
    ShowTransfers,
    Close
}

//TODO:
// Está pedindo quanto sacar 2 vezes