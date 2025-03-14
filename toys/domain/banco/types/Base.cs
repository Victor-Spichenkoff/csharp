using System.Globalization;
using Inputs;
using Microsoft.Extensions.DependencyInjection;
using toys.Data;
using toys.utils;

namespace toys.banco.types;

public class BaseAccount
{
    protected int Id { get; set; }
    protected string Holder { get; set; }
    protected double Balance { get; set; }
    protected double SpecialCheck { get; set; }


    protected BankRepository _bankRepository { get; set; }
    protected AccountType AccountType { get; set; }

    protected BaseAccount(int id, AccountType accountType, string holder, double balance, double specialCheck = 0)
    {
        Id = id;
        Holder = holder;
        Balance = balance;
        AccountType = accountType;
        SpecialCheck = specialCheck;
        // automático
        var serviceProvider = ContextUtils.ConfigureDI();

        var scope = serviceProvider.CreateScope();
        _bankRepository = scope.ServiceProvider.GetRequiredService<BankRepository>();
    }

    /*
     * Callback -> executada apos receber o valor e conferir balanço.
     * Deve retornar o valor final a ser descontado/adicionado
     */
    public virtual bool Sake(SakeCallback? callback = null)
    {
        try
        {
            var valueString = Input.String("Withdraw how much (or q)? ");
            if (valueString.ToLower() == "q") return false;

            var preValue = Convert.ToDouble(valueString);

            var account = _bankRepository.GetAccountByHolder(Holder);
            if (account == null || account?.Balance - preValue + SpecialCheck < 0)
                throw new MyError("Not enough money! Poor!");

            // responsividade
            double value = preValue;
            if (callback != null)
                value = callback(value);

            account.Balance -= value;
            var success = _bankRepository.UpdateAccount(account);
            if (!success)
                return false;

            AddTransfer(Holder, "WITHDRAWAL", value * -1, TransferType.Withdraw);

            Console.WriteLine($"Cashing out: ${value}");
            return true;
        }
        catch (MyError myErr)
        {
            throw new MyError(myErr.Message);
        }
        catch
        {
            return Sake(callback);
        }
    }


    /*
     * Cuida de tudo: pergunta, manda realizar e salva
     */
    public virtual bool Transfer(SakeCallback? callback = null)
    {
        try
        {
            var receiverName = Input.String("Receiver NAME (or q): ");
            var receiverAccount = _bankRepository.GetAccountByHolder(receiverName);
            if (receiverAccount == null)
                throw new MyError("User doesn't exist");

            var baseValue = Input.Double("Transfer how much? ");
            if (receiverName.ToLower() == "q") return false;


            var account = _bankRepository.GetAccountByHolder(Holder);
            if (account == null || account?.Balance - baseValue + SpecialCheck < 0)
                throw new MyError("Not enough money! Poor!");

            // responsividade
            double value = baseValue;
            if (callback != null)
                value = callback(value);


            Console.WriteLine($"Paying {value} to {receiverName}: ${value}");

            var cont = Input.BoolEnglish("Confirm [y/n]: ");

            if (!cont)
                throw new MyError("Operation cancelled");

            MakeTransfer(Holder, receiverName, value);
            return true;
        }
        catch
        {
            return Sake(callback);
        }
    }

    public virtual double GetBalance()
    {
        var account = _bankRepository.GetAccountByHolder(Holder);
        Balance = account.Balance;
        Console.WriteLine($"\n\n\nBalance: ${Balance}");

        return Balance;
    }


    public bool ShowTransfers(bool skipQuestion = false)
    {
        var transfersToShow = Input.Int("How many? ");

        if (transfersToShow < 0)
            return ShowTransfers();

        var transfers = _bankRepository.GetTransfersDescendent(Holder, transfersToShow);

        Console.WriteLine("================= TRANSFERS =================");
        Console.WriteLine("     ID           Date                Sender                  ");
        foreach (var transfer in transfers)
        {
            var formattedId = transfer.Id.ToString().Substring(0, 8);
            Console.WriteLine(
                $"[ {formattedId} ] {transfer.DateAndTime.ToLocalTime()} | |   {transfer.SenderHolder} -> {transfer.ReceiverHolder} -- $ {transfer.Amount}   [ {transfer.Type.ToString()} ]");
        }

        if (transfers.Count < transfersToShow)
        {
            Console.WriteLine("That's all!");
            return false;
        }


        var count = 2; //para o skip
        while (true)
        {
            var more = Input.BoolEnglish("Show More [y/n]? ");
            if (!more)
                return true;

            var newTransfers = _bankRepository.GetTransfersDescendent(Holder, transfersToShow, transfersToShow * count);

            foreach (var transfer in newTransfers)
            {
                var formattedId = transfer.Id.ToString().Substring(0, 4);
                Console.WriteLine($"ID - {formattedId} -- ${transfer.DateAndTime.ToLocalTime()} -- ${transfer.Amount}");
            }

            if (newTransfers.Count < transfersToShow)
            {
                Console.WriteLine("That's all!");
                return false;
            }

            count++;
        }

        return true;
    }


    /*
     * Depositar -> +
     * Enviar a outro -> - (baseado no )
     */
    protected void AddTransfer(string senderHolder, string receiverHolder, double value,
        TransferType transferType = TransferType.Transfer)
    {
        var transference = new Transference()
        {
            ReceiverHolder = receiverHolder,
            SenderHolder = senderHolder,
            Amount = value,
            Type = transferType
        };
        _bankRepository.CreateTransference(transference);
    }

    public void ShowAccountInfos()
    {
        Console.Clear();
        var specialCheckLabel = (SpecialCheck > 0 ? SpecialCheck.ToString(CultureInfo.CurrentCulture) : "NOT ALLOWED");
        Console.WriteLine("\n\n================= ACCOUNT INFOS =================");
        Console.WriteLine($"ID           : {Id}");
        Console.WriteLine($"Holder       : {Holder}");
        Console.WriteLine($"Balance      : {Balance}");
        Console.WriteLine($"Special Check: {specialCheckLabel}");
        Console.WriteLine($"Type         : {AccountType}");
        Console.WriteLine("=================================================\n");
    }

    public void Deposit()
    {
        var amount = Input.Double("Deposit amount: ");
        var account = _bankRepository.GetAccountByHolder(Holder);

        account.Balance += amount;

        _bankRepository.UpdateAccount(account);

        Console.WriteLine($"Deposited {amount} to {Holder}");
        Console.WriteLine("===============================================");
    }

    public void UndoTransfer()
    {
        var transferId = Input.String("Transfer ID [or q]: ");
        if (transferId.ToLower() == "q")
        {
            BankEntry.Mode = Modes.SelectionLogged;
            throw new JustBreak("Operation cancelled");
        }

        var transfersWithId = _bankRepository.GetTransferenceByStartId(transferId, Holder);

        if (transfersWithId.Count == 0)
            throw new MyError($"No transfer with ID {transferId} found in your account!");

        if (transfersWithId.Count > 1)
        {
            Console.WriteLine("\nMore than one transfer with that ID");
            Console.WriteLine("================= TRANSFERS =================");
            // Console.WriteLine("     ID           Date            Sender                  ");
            foreach (var transfer in transfersWithId)
                Console.WriteLine(
                    $"[ {transfer.Id} ] {transfer.DateAndTime.ToLocalTime()} -- {transfer.SenderHolder} -> {transfer.ReceiverHolder} -- $ {transfer.Amount}");

            UndoTransfer();
            return;
        }

        if (transfersWithId[0].Type != TransferType.Transfer)
            throw new MyError("You can only undo TRANSFERS!");

        var value = transfersWithId[0].Amount;

        MakeTransfer(transfersWithId[0].ReceiverHolder, transfersWithId[0].SenderHolder, value, TransferType.Undo);
        _bankRepository.DeleteTransfer(transfersWithId[0]);

        Console.WriteLine($"UNDO transfer with ID: {transferId}");
    }


    public void ChangeInformation()
    {
        Console.WriteLine("==================== INFORMATION ====================");
        Console.WriteLine($"Just press ENTER to SKIP");
        var specialCheckLabel = (AccountType is AccountType.Salary or AccountType.Savings or AccountType.Digital
            ? "NOT ALLOWED"
            : SpecialCheck.ToString(CultureInfo.CurrentCulture));
        Console.WriteLine($"[ CURRENT ] Special Check: {specialCheckLabel}");
        if (specialCheckLabel.Contains("NOT"))
        {
            Console.WriteLine("You can't change it!");
        }
        else
        {
            var newSpecialCheck = Input.String("Enter NEW Special Check [q]: ");
            if (newSpecialCheck.ToLower() == "q")
            {
                BankEntry.Mode = Modes.SelectionLogged;
                return;
            }

            var maxSpecialCheck = AccountType == AccountType.Current ? Balance * 0.5 : Balance;

            var account = _bankRepository.GetAccountByHolder(Holder);
            if (account == null)
                throw new MyError($"Account with holder [{Holder}] does not exist!");


            try
            {
                var newSpecialCheckDouble = Double.Parse(newSpecialCheck.Trim());
                if (newSpecialCheckDouble > maxSpecialCheck)
                    throw new MyError($"The value ${newSpecialCheckDouble} excedes your limit of ${maxSpecialCheck}");

                account.SpecialCheck += newSpecialCheckDouble;
            }
            catch (MyError myError)
            {
                throw new MyError(myError.Message);
            }
            catch
            {
                throw new MyError($"Invalid number {newSpecialCheck}");
            }

            Console.WriteLine("NEW INFORMATIONS:");
            Console.WriteLine($"Special Check: ${newSpecialCheck}");
            var cont = Input.BoolEnglish("Continue [y/n]: ");
            if (!cont)
                throw new MyError("Operation cancelled");

            _bankRepository.UpdateAccount(account);
        }
    }

    public void MakeTransfer(string sender, string receiver, double amount, TransferType type = TransferType.Transfer)
    {
        var senderAccount = _bankRepository.GetAccountByHolder(sender);
        var receiverAccount = _bankRepository.GetAccountByHolder(receiver);

        if (senderAccount == null || receiverAccount == null)
            throw new MyError("One or more account weren't found");

        senderAccount.Balance -= amount;
        receiverAccount.Balance += amount;

        _bankRepository.UpdateAccount(senderAccount);
        _bankRepository.UpdateAccount(receiverAccount);

        AddTransfer(sender, receiver, amount, type);
    }

    public void ShowAccounts()
    {
        var accounts = _bankRepository.GetAccounts();

        Console.WriteLine("\n\n======================== ACCOUNTS ========================");
        foreach (var a in accounts)
        {
            Console.WriteLine($"[ {a.Id} ]  {a.Holder.PadRight(12)}   |   {a.AccountType.ToString().PadRight(12)}   |   ${a.Balance.ToString().PadLeft(12)}");
        }
        Console.WriteLine("==========================================================\n");
    }
}

public delegate double SakeCallback(double entryValue);