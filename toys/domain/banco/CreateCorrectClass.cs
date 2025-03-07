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
            default:
                return new Current(accountInfo.Holder, accountInfo.Balance);
        }
    }
}