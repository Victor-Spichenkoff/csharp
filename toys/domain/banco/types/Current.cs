namespace toys.banco.types;

public class Current: BaseAccount
{
    public Current(int id, string holder, double balance) : base(id, AccountType.Current, holder, balance) {}
    
    
}