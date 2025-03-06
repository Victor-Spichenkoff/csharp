namespace toys.banco.types;

public class Current: BaseAccount
{
    Current(string holder, double balance) : base(AccountType.Current, holder, balance) {}
    
    
}