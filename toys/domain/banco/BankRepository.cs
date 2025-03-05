using toys.Data;

namespace toys.banco;

public class BankRepository(DataContext db)
{
    private readonly DataContext _context = db;

    public IList<Account> GetAccounts() =>
        _context.Accounts.ToList();

    public bool CreateAccount(Account account)
    {
        _context.Accounts.Add(account);
        return _context.SaveChanges() > 0;
    }
}