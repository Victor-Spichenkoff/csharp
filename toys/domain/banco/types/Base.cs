using Inputs;
using Microsoft.Extensions.DependencyInjection;
using toys.Data;

namespace toys.banco.types;

public class BaseAccount
{
    public int Id { get; set; }
    public string Holder { get; set; }
    public double Balance { get; set; }

    protected BankRepository _bankRepository { get; set; }
    public AccountType AccountType { get; set; }
    public IList<Transference> Transfers { get; set; } = [];

    protected BaseAccount(int id, AccountType accountType, string holder, double balance)
    {
        Id = id;
        Holder = holder;
        Balance = balance;
        AccountType = accountType;
        // automático
        var serviceProvider = ContextUtils.ConfigureDI();

        //TODO:> pediu para ser assim
        // using (var scope = serviceProvider.CreateScope())
        // {
            // _bankRepository = scope.ServiceProvider.GetRequiredService<BankRepository>();
        // }
        var scope = serviceProvider.CreateScope();
        _bankRepository = scope.ServiceProvider.GetRequiredService<BankRepository>();
        
        //TODO:
        Console.WriteLine("PEGAR TRASNFERENCIAS");
        var test = _bankRepository.GetTransfersDescendent();
        Console.WriteLine(test);
    }

    public virtual bool Sake()
    {
        try
        {
            var valueString = Input.String("Withdraw how much (or q)? ");
            if (valueString.ToLower() == "q") return false;

            var value = Convert.ToDouble(valueString);

            var account = _bankRepository.GetAccountByHolder(Holder);
            if (account == null || account?.Balance - value < 0)
                return false;

            account.Balance -= value;
            var success = _bankRepository.UpdateAccount(account);
            if (!success)
                return false;

            AddTransfer(Holder, "WITHDRAWAL", value * -1);
            
            Console.WriteLine($"Cashing out: ${value}");
            return true;
        }
        catch
        {
            return Sake();
        }
    }

    public virtual double GetBalance()
    {
        var account = _bankRepository.GetAccountByHolder(Holder);
        Balance = account.Balance;
        Console.WriteLine($"\n\n\nBalance: ${Balance}");

        return Balance;
    }


    public bool ShowTransfers(bool skipQuestion = false)
    {
        var transfersToShow = Input.Int("How much? ");

        if (transfersToShow < 0)
            return ShowTransfers();

        var transfers = _bankRepository.GetTransfersDescendent(transfersToShow);

        Console.WriteLine("================= TRANSFERS =================");
        
        foreach (var transfer in transfers)
        {
            var formattedId = transfer.Id.ToString().Substring(0, 4);
          Console.WriteLine($"ID - {formattedId} -- ${transfer.DateAndTime.ToLocalTime()} -- ${transfer.Amount}");  
        }
        
        if (transfers.Count < transfersToShow)
        {
            Console.WriteLine("That's all!");
            return false;
        }


        var count = 2;//para o skip
        while (true)
        {
            var more = Input.BoolEnglish("Show More [y/n]? ");
            if (!more)
                return true;
            
            var newTransfers = _bankRepository.GetTransfersDescendent(transfersToShow, transfersToShow * count);
            
            foreach (var transfer in newTransfers)
            {
                var formattedId = transfer.Id.ToString().Substring(0, 4);
                Console.WriteLine($"ID - {formattedId} -- ${transfer.DateAndTime.ToLocalTime()} -- ${transfer.Amount}");  
            }

            if (newTransfers.Count < transfersToShow)
            {
                Console.WriteLine("That's all!");
                return false;
            }
            
            count++;
        }
        return true;
    }
    
    
    /*
     * Depositar -> +
     * Enviar a outro -> - (baseado no )
     */
    protected void AddTransfer(string senderHolder, string receiverHolder, double value)
    {
        var transference = new Transference()
        {
            ReceiverHolder = receiverHolder,
            SenderHolder = senderHolder,
        };
        _bankRepository.CreateTransference(transference);
    }
}