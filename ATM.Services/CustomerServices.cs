﻿using ATM.Models;
using ATM.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATM.Services
{
   public class CustomerServices // write Interfaces which inherit all the methods inside this service
    {
        Bank bank;
        readonly BankContext bankcontext = new BankContext();
  /*      public CustomerServices( )
        {
            using (BankContext bankContext = new BankContext())
            {
                bankContext.Database.EnsureCreated();
            }
        }
  */

        public void deposit(double amount, Account user, string currentycode, string bankid)  // static
        {
          try{
               
                user.currentbalance += (amount * bankcontext.Currency.FirstOrDefault(c=>c.code == currentycode).exchangerate);  // check
                Transaction transaction = new Transaction(user.Id , user.Id, amount, DateTime.Now, TransactionType.Credited, bankid, bankid);
                user.Transactions.Add(transaction);
               // return user.currentbalance;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
        public bool withdraw(double amount, string accountId , Account user , string bankid)
        {
            if(user.currentbalance >= amount)
            { 
           
            //   return amount.currentbalance -= amount;
            user.currentbalance -= amount;
            Transaction transaction = new Transaction( user.Id , user.Id , amount , DateTime.Now , TransactionType.Debited  , bankid , bankid);
            user.Transactions.Add(transaction);
            return true;
            }
            return false;
        }
        public bool transfer(double amount, string accountId1, string accountId2 , string SenderBankId , string RecieverBankId , string choice , string senderbankcurrencycode)
        {
         Bank SenderBank;
         Bank RecieverBank;
            try
            {
                using (BankContext bankContext = new BankContext())
                {
                    SenderBank = bankContext.Bank.FirstOrDefault(b => b.Id == SenderBankId);
                    RecieverBank = bankContext.Bank.FirstOrDefault(b => b.Id == RecieverBankId);
                    if (SenderBank == null || RecieverBank == null)
                    {
                        throw new BankDoesnotExistException();
                    }
                }

               // foreach(var i in BankList.Banks)
                   /* foreach(var i in Bank)
                {
                    if(i.Id==SenderBankId)
                    {
                        bank = i;  // senderbank
                    }
                    if(i.Id==RecieverBankId)
                    {
                        RecieverBank =i;
                    }
                } */
                double charge;
                if(SenderBankId==RecieverBankId)
                {
                    if( choice =="1")
                    {
                        charge = DeductCharge(amount, bank.RTGSsameBank);
                    }
                    else
                    {
                        charge = DeductCharge(amount, bank.IMPSsameBank);
                    }
                }
                else
                {
                    if (choice == "1")
                    {
                        charge = DeductCharge(amount, bank.RTGSdifferentBank);
                    }
                    else
                    {
                        charge = DeductCharge(amount, bank.IMPSdifferentBank);
                    }

                }
                Account account1 = bankcontext.Account.FirstOrDefault(m => m.Id == accountId1);
                if (account1 == null)
                {
                    throw new UserNotFoundException();
                }
                Account account2 = bankcontext.Account.FirstOrDefault(m => m.Id == accountId2);
                if (account2 == null)
                {
                    throw new UserNotFoundException();
                }
                if (account1.currentbalance >= amount + charge)
                {
                    account1.currentbalance -= amount + charge;
                    account2.currentbalance += Math.Round(amount * (bankcontext.Currency.FirstOrDefault(a => a.code == senderbankcurrencycode).exchangerate));
                    return true;
                }
             //   account2.currentbalance += amount;
             //   account1.currentbalance -= amount;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in Transfer: {0}", ex.Message);
            }
            return false;

        }
        public double DeductCharge(double amount , double percent )
        {
            return (double)Math.Round(amount*percent , 2);
        }
    
        public Account GetAccount(string accId)
        {
            foreach (var acc in bankcontext.Account)
            {
                if (acc.Id == accId) return acc;
            }
            return null;
        }

    }
    }














