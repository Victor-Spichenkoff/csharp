namespace toys.banco.types;

public class Current: BaseAccount
{
    public Current(string holder, double balance) : base(AccountType.Current, holder, balance) {}
    
    
}