namespace toys.banco;

public class Account()
{
    public int Id { get; set; }
    public string Holder { get; set; } = String.Empty;
    public double Balance { get; set; }
    public AccountType AccountType { get; set; }
}

public enum AccountType
{
    Current,
    Savings,
    Salary,
    Digital,
    Investments
}