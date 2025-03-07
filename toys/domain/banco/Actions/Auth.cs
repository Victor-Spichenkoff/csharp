using Inputs;

namespace toys.banco.Actions.Create;

public class Auth(BankRepository br)
{
    private readonly BankRepository _br = br;


    public Account CreateAccount()
        // public void CreateAccount()
    {
        var holder = Input.String("Your name: ");
        var balance = Input.Double("Your start balance: ");
        Console.WriteLine("[ 1 ] - Current");
        Console.WriteLine("[ 2 ] - Savings");
        Console.WriteLine("[ 3 ] - Salary");
        Console.WriteLine("[ 4 ] - Digital");
        Console.WriteLine("[ 5 ] - Investments");
        var typeNumber = Input.Int("Account type: ");

        var type = AccountType.Current;
        // Investments
        switch (typeNumber)
        {
            case 2:
                type = AccountType.Savings; break;
            case 3:
                type = AccountType.Salary; break;
            case 4:
                type = AccountType.Digital; break;
            case 5:
                type = AccountType.Investments; break;
        }


        var account = new Account()
        {
            Holder = holder,
            Balance = balance,
            AccountType = type,
        };

        Console.WriteLine($"Holder : {holder}");
        Console.WriteLine($"Balance: {balance}");
        Console.WriteLine($"Type   : {type.ToString()}");

        var isCorrect = Input.BoolEnglish("Is that correct?[y/n] ");
        if (!isCorrect)
        {
            Console.WriteLine("Asking again...");
            return CreateAccount();
        }

        return _br.CreateAccount(account);
    }

    public Account Login()
    {
        var holder = Input.String("Holder: ");
        var account = _br.GetAccountByHolder(holder);

        if (account != null)
            return account;

        var accounts = _br.GetAccounts();
        foreach (var a in accounts)
            Console.WriteLine($"[ {a.Id} ] - {a.Holder}");

        Console.WriteLine("What will be: ");

        return Login();
    }

    public void ShowAccounts()
    {
    }
}