using toys.Data;

namespace toys.banco;

public class BankRepository(DataContext db)
{
    private readonly DataContext _context = db;

    
    
    public Account? GetAccountByHolder(string holder) =>
    _context.Accounts.FirstOrDefault(a => a.Holder == holder);
    
    public IList<Account> GetAccounts() =>
        _context.Accounts.ToList();

    public Account CreateAccount(Account account)
    {
        if(_context.Accounts.Any(a => a.Holder == account.Holder ))
            throw new Exception("Holder already exists");
        
        _context.Accounts.Add(account);
        _context.SaveChanges();
        return _context.Accounts.FirstOrDefault(a => a.Holder == account.Holder);
    }

    public void DeleteAccountByHolder(string holder)
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Holder == holder);
        if(account == null)
            return;
        _context.Accounts.Remove(account);
        _context.SaveChanges();
    }
}