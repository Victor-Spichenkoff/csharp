using System.Globalization;
using Inputs;
using Microsoft.Extensions.DependencyInjection;
using toys.Data;
using toys.utils;

namespace toys.banco.types;

public class BaseAccount
{
    public int Id { get; set; }
    public string Holder { get; set; }
    public double Balance { get; set; }
    public double SpecialCheck { get; set; }


protected BankRepository _bankRepository { get; set; }
    public AccountType AccountType { get; set; }

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
            if (account == null || account?.Balance - preValue < 0)
                return false;

            // responsividade
            double value = preValue;
            if(callback != null)
                value = callback(value);
                
            account.Balance -= value;
            var success = _bankRepository.UpdateAccount(account);
            if (!success)
                return false;

            AddTransfer(Holder, "WITHDRAWAL", value * -1, TransferType.Withdraw);
            
            Console.WriteLine($"Cashing out: ${value}");
            return true;
        }
        catch
        {
            return Sake(callback);
        }
    }

    
    /*
     * Cuida de tudo, pergunta, manda realizar e salva
     */
    // public virtual bool Transfer(SakeCallback? callback = null, string senderHolder)
    // {
    //     try
    //     {
    //         var valueString = Input.String("Transfer how much (or q)? ");
    //         var recieverId = 
    //         if (valueString.ToLower() == "q") return false;
    //
    //         var preValue = Convert.ToDouble(valueString);
    //
    //         var account = _bankRepository.GetAccountByHolder(Holder);
    //         if (account == null || account?.Balance - preValue < 0)
    //             return false;
    //
    //         // responsividade
    //         double value = preValue;
    //         if(callback != null)
    //             value = callback(value);
    //             
    //         account.Balance -= value;
    //         var success = _bankRepository.UpdateAccount(account);
    //         if (!success)
    //             return false;
    //
    //         AddTransfer(Holder, "WITHDRAWAL", value * -1);
    //         
    //         Console.WriteLine($"Cashing out: ${value}");
    //         return true;
    //     }
    //     catch
    //     {
    //         return Sake(callback);
    //     }
    // }
    //
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
            Console.WriteLine($"[ {formattedId} ] {transfer.DateAndTime.ToLocalTime()} | |   {transfer.SenderHolder} -> {transfer.ReceiverHolder} -- $ {transfer.Amount}   [ {transfer.Type.ToString()} ]");  
        }
        
        if (transfers.Count < transfersToShow)
        {
            Console.WriteLine("That's all!");
            return false;
        }


        var count = 2;//para o skip
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
    protected void AddTransfer(string senderHolder, string receiverHolder, double value, TransferType transferType = TransferType.Transfer)
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

    // id sender            receiver [UNDO]
    //435 antigo_receiver   antigo_sender
    
    public void UndoTransfer()
    {
        var transferId = Input.String("Transfer ID: ");
        var transfersWithId = _bankRepository.GetTransferenceByStartId(transferId, Holder);
        
        //TODO: PARA TESTERS
        transfersWithId.Add(transfersWithId[0]);
        
        
        
        if(transfersWithId.Count == 0)
            throw new MyError($"No transfer with ID {transferId} found");

        if (transfersWithId.Count > 1)
        {
            Console.WriteLine("More than one transfer with that ID");
            Console.WriteLine("================= TRANSFERS =================");
            Console.WriteLine("     ID           Date            Sender                  Value");
            foreach (var transfer in transfersWithId)
                Console.WriteLine($"[ {transferId} ] {transfer.DateAndTime.ToLocalTime()} -- {transfer.SenderHolder} -> {transfer.ReceiverHolder} -- $ {transfer.Amount}");  
            
            UndoTransfer();
            return;
        }
        
        // TODO:
        // Apagar a transferência e devolver os valores
        //devolver:
        var value = transfersWithId[0].Amount;

        // TODO: Vai ser uma transferencia
        MakeTransfer(transfersWithId[0].ReceiverHolder, transfersWithId[0].SenderHolder, value, TransferType.Undo);

    }


    public void MakeTransfer(string sender, string receiver, double amount, TransferType type = TransferType.Transfer)
    {
        var senderAccount = _bankRepository.GetAccountByHolder(sender);
        var receiverAccount = _bankRepository.GetAccountByHolder(receiver);
        
        if(senderAccount == null || receiverAccount == null)
            throw new MyError("One or more account weren't found");
        
        senderAccount.Balance -= amount;
        receiverAccount.Balance += amount;

        _bankRepository.UpdateAccount(senderAccount);
        _bankRepository.UpdateAccount(receiverAccount);
        
        AddTransfer(sender, receiver, amount, type);
    }
}


public delegate double SakeCallback(double entryValue);