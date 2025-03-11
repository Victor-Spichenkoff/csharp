using toys.Data;
using toys.utils;

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
            throw new MyError("Holder already exists");
        
        _context.Accounts.Add(account);
        _context.SaveChanges();
        return _context.Accounts.FirstOrDefault(a => a.Holder == account.Holder);
    }

    public bool UpdateAccount(Account account)
    {
        _context.Accounts.Update(account);
        return _context.SaveChanges() > 0;
    }
    
    public void DeleteAccountByHolder(string holder)
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Holder == holder);
        if(account == null)
            return;
        _context.Accounts.Remove(account);
        _context.SaveChanges();
    }
    
    
    
    // tranferencias
    public void CreateTransference(Transference transference)
    {
        var transferenceCreated = _context.Transferences.Add(transference);
        _context.SaveChanges();
    }

    public IList<Transference> GetTransfersDescendent(string holder, int size = 3, int skip = 0)
    {
        return _context.Transferences
            .Where(t => t.SenderHolder == holder || t.ReceiverHolder == holder)
            .OrderByDescending(a => a.DateAndTime)
                .Skip(skip)
                .Take(size)
                .ToList();
    }
}