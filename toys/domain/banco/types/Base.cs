using Microsoft.Extensions.DependencyInjection;
using toys.Data;

namespace toys.banco.types;

public class BaseAccount
{
    private static int _lastId = 0;
    public int Id { get; set; }
    public string Holder { get; set; }
    public double Balance { get; set; }

    public BankRepository BankRepository { get; set; }
    public AccountType AccountType { get; set; }
    public IList<Transference> Transfers { get; set; } = [];

    protected BaseAccount(AccountType accountType, string holder, double balance)
    {
        Holder = holder;
        Balance = balance;
        AccountType = accountType;
        // automático
        var scope = ContextUtils.ConfigureDI();
        _lastId += 1;
        Id = _lastId;
        if (scope != null)
            BankRepository = scope.ServiceProvider.GetRequiredService<BankRepository>();
        else
        {
            
            throw new Exception("Scope is null");
        }
    }

    public virtual void Sake(double value)
    {
    }

    public double GetBalance()
    {
        return 0;
    }

    /*
     * Depositar -> +
     * Enviar a outro -> - (baseado no )
     */
    protected void AddTransfer(string senderHolder, string receiverHolder, int accountId, double value)
    {
    }
}