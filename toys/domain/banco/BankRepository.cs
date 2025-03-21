﻿using Microsoft.EntityFrameworkCore;
using toys.Data;
using toys.utils;

namespace toys.banco;

public class BankRepository(DataContext db)
{
    private readonly DataContext _context = db;



    public Account? GetAccountByHolder(string holder) =>
        _context.Accounts.FirstOrDefault(a => a.Holder == holder);

    
    public IList<Account> GetAccounts() =>
        _context.Accounts.ToList();

    public Account CreateAccount(Account account)
    {
        if(_context.Accounts.Any(a => a.Holder == account.Holder ))
            throw new MyError("Holder already exists");

        //special check
        if (account.AccountType == AccountType.Investments && account.Balance > 100)
        {
            var finalSpecialCheck = account.Balance * 0.7;
            Console.WriteLine($"You have access to a 70% special check: ${finalSpecialCheck}");
            account.SpecialCheck = finalSpecialCheck;
        }
        else if (account.AccountType == AccountType.Current && account.Balance > 100)
        {
            var finalSpecialCheck = account.Balance * 0.3;
            Console.WriteLine($"You have access to a 30% special check: ${finalSpecialCheck}");
            account.SpecialCheck = finalSpecialCheck;
        }

        _context.Accounts.Add(account);
        _context.SaveChanges();
        return _context.Accounts.FirstOrDefault(a => a.Holder == account.Holder);
    }

    public bool UpdateAccount(Account account)
    {
        _context.Accounts.Update(account);
        return _context.SaveChanges() > 0;
    }
    
    public void DeleteAccountByHolder(string holder)
    {
        var account = _context.Accounts.FirstOrDefault(a => a.Holder == holder);
        if(account == null)
            return;
        _context.Accounts.Remove(account);
        _context.SaveChanges();
    }
    
    
    
    // tranferencias
    public void CreateTransference(Transference transference)
    {
        var transferenceCreated = _context.Transferences.Add(transference);
        _context.SaveChanges();
    }

    public IList<Transference> GetTransfersDescendent(string holder, int size = 3, int skip = 0)
    {
        return _context.Transferences
            .Where(t => t.SenderHolder == holder || t.ReceiverHolder == holder)
            .OrderByDescending(a => a.DateAndTime)
                .Skip(skip)
                .Take(size)
                .ToList();
    }


    public IList<Transference> GetTransferenceByStartId(string startId, string senderName) =>
        _context.Transferences
            .Where(t => t.Id.ToString().StartsWith(startId) && t.SenderHolder == senderName)
            // .AsNoTracking()
            .ToList();
        

    public void DeleteTransfer(Transference? transference = null, string? transferId = null)
    {
        // if (transference != null)
        //     _context.Transferences.Remove(transference);
        // else if(transferId != null)
        // {
        //     var transfer = _context.Transferences.FirstOrDefault(t => t.Id.ToString().StartsWith(transferId));
        // } 
        if(transferId != null)
        { 
            transference = _context.Transferences.FirstOrDefault(t => t.Id.ToString().StartsWith(transferId));
        }
        else if (transference == null)
            throw new MyError("Missing information!");
        
        _context.Transferences.Remove(transference);
        _context.SaveChanges();
    }
    
}