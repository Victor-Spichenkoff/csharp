namespace toys.banco.types;

public class Current: BaseAccount
{
    public Current (int id, string holder, double balance, double specialCheck) : base(id, AccountType.Savings, holder, balance, specialCheck) {}
}