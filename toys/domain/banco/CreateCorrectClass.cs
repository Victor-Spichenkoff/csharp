using toys.banco.types;

namespace toys.banco;

public class CreateCorrectClass
{
    public static BaseAccount GiveAccount(Account accountInfo)
    {
        switch (accountInfo.AccountType)
        {
            //TODO: Criar as outras contas
            // outros tipos
            // case AccountType:
            //     return new Current(accountInfo.Holder, accountInfo.Balance);
            case AccountType.Savings:
                return new Savings(accountInfo.Id, accountInfo.Holder, accountInfo.Balance, accountInfo.SpecialCheck);
            case AccountType.Salary:
                return new Salary(accountInfo.Id, accountInfo.Holder, accountInfo.Balance, accountInfo.SpecialCheck);
            case AccountType.Digital:
                return new Salary(accountInfo.Id, accountInfo.Holder, accountInfo.Balance, accountInfo.SpecialCheck);
            case AccountType.Investments:
                return new Investments(accountInfo.Id, accountInfo.Holder, accountInfo.Balance, accountInfo.SpecialCheck);
            default:
                return new Current(accountInfo.Id, accountInfo.Holder, accountInfo.Balance, accountInfo.SpecialCheck);
        }
    }
}