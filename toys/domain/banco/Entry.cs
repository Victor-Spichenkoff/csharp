using Microsoft.Extensions.DependencyInjection;
using toys.banco.Actions.Create;
using toys.banco.types;
using toys.Data;
using toys.utils;

namespace toys.banco;

public class BankEntry
{
    private readonly BankRepository _br;
    public static Modes Mode = Modes.SelectionInitial;
    private BaseAccount? _currentAccount = null;

    public BankEntry()
    {
        var serviceProvider = ContextUtils.ConfigureDI();

        var scope = serviceProvider.CreateScope();
        _br = scope.ServiceProvider.GetRequiredService<BankRepository>();
        // using (var scope = serviceProvider.CreateScope())
        // {
        //     _br = scope.ServiceProvider.GetRequiredService<BankRepository>();
        // }
    }

    public void RunningMode()
    {
        while (true)
        {
            if (Mode == Modes.SelectionInitial)
            {
                Mode = ModeHandler.SelectInitialType();
                continue; // para não usar o Sleep
            }
            else if (Mode == Modes.Close)
                break;
            else if (Mode == Modes.SelectionLogged) // já logado, o que fazer?
            {
                Mode = ModeHandler.SelectType();
                continue; // para não passar pelo Sleep
            }

            if (Mode == Modes.Login)
            {
                var auth = new Auth(_br);
                var accountInfo = auth.Login();
                if (accountInfo == null)
                {
                    Mode = Modes.SelectionInitial;
                    continue;
                }
                else
                {
                    _currentAccount = CreateCorrectClass.GiveAccount(accountInfo);
                    Mode = Modes.SelectionLogged;
                }
            }
            else if (Mode == Modes.Register)
            {
                var auth = new Auth(_br);
                var accountInfo = auth.CreateAccount();
                _currentAccount = CreateCorrectClass.GiveAccount(accountInfo);
                Mode = Modes.SelectionLogged;
            }


            // controlar as açoes pós login
            switch (Mode)
            {
                case Modes.Consult:
                    Mode = Modes.SelectionLogged;
                    _currentAccount?.GetBalance();
                    break;
                case Modes.Sake:
                    _currentAccount?.Sake();
                    Mode = Modes.SelectionLogged;
                    break;
                case Modes.ShowTransfers:
                    _currentAccount?.ShowTransfers();
                    Mode = Modes.SelectionLogged;
                    break;
                case Modes.ShowInformation:
                    _currentAccount?.ShowAccountInfos();
                    Mode = Modes.SelectionLogged;
                    break;
                case Modes.Transfer:
                    _currentAccount?.Transfer();
                    Mode = Modes.SelectionLogged;
                    break;
                case Modes.UndoTransfer:
                    _currentAccount?.UndoTransfer();
                    Mode = Modes.SelectionLogged;
                    break;
                case Modes.Close:
                    Console.WriteLine("Closing Bank");
                    break;
                    break;
                // todo:
                //criar desfazer transfer
                default: break;
            }

            // Deixar melhor de ler
            // if (Mode == Modes.SelectionLogged)
            //     Thread.Sleep(2000);
        }
    }

    //TODO:
    //Formatar saida das transferências:

    

    public void Run()
    {
        try
        {
            RunningMode();
        }
        catch (Exception ex)
        {
            ErrorHandler.ShowError(ex);
            Run();
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
    Transfer,
    SelectionInitial,
    SelectionLogged,
    Exit,
    ShowTransfers,
    Close,
    ShowInformation,
    UndoTransfer
}

//TODO:
// Está pedindo quanto sacar 2 vezes